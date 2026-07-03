const API_URL_Candidate = '/api/candidate';
const API_URL_Patient = '/api/patient';
const API_URL_Heart = '/api/heart';

async function fetchPatients() {
    try {
        const response = await fetch(API_URL_Patient);

        if (!response.ok) {
            throw new Error(`Patients-API Server-Fehler: ${response.status}`);
        }

        const data = await response.json();
        const listContainer = document.getElementById('patient-list');

        if (!listContainer) return;
        listContainer.innerHTML = '';

        data.forEach(patient => {
            const listItem = document.createElement('li');
            listItem.textContent = `${patient.firstname} ${patient.lastname} - Bloodtype: ${patient.bloodType}`;
            listContainer.appendChild(listItem);
        });
    } catch (error) {
        console.error("Fehler in fetchPatients():", error);
    }
}

async function fetchHearts() {
    try {
        const response = await fetch(API_URL_Heart);

        if (!response.ok) {
            throw new Error(`Hearts-API Server-Fehler: ${response.status}`);
        }

        const data = await response.json();
        const listContainer = document.getElementById('heart-list');

        if (!listContainer) return;
        listContainer.innerHTML = '';

        data.forEach(heart => {
            const listItem = document.createElement('li');
            listItem.textContent = `ID: ${heart.id} - Bloodtype: ${heart.bloodType}`;
            listContainer.appendChild(listItem);
        });
    } catch (error) {
        console.error("Fehler in fetchHearts():", error);
    }
}

async function fetchCandidates() {
    try {
        const response = await fetch(API_URL_Candidate);

        if (!response.ok) {
            throw new Error(`Matches-API Server-Fehler: ${response.status}`);
        }

        const data = await response.json();
        const listContainer = document.getElementById('candidate-list');

        if (!listContainer) return;
        listContainer.innerHTML = '';

        data.forEach(candidate => {
            const listItem = document.createElement('li');
            listItem.className = 'candidate-item';

            listItem.innerHTML = `
                <div>
                    <span>
                        Patient: ${candidate.recipientPatient.firstname} ${candidate.recipientPatient.lastname}
                    </span>
                    <span>Blutgruppe: ${candidate.recipientPatient.bloodType}</span>
                </div>
                <div>
                    Empfängt Spenderorgan: Herz-ID ${candidate.donorHeart.id}
                    <span>Spender-BG: ${candidate.donorHeart.bloodType}</span>
                </div>
            `;

            listContainer.appendChild(listItem);
        });
    } catch (error) {
        console.error("Fehler in fetchCandidates():", error);
    }
}

fetchPatients();
fetchHearts();
fetchCandidates();

async function addPatient() {

        const patient = {
            firstname: document.getElementById("firstname").value,
            lastname: document.getElementById("lastname").value,
            bloodtype: document.getElementById("bloodtype").value,
            bodyweight: parseFloat(document.getElementById("bodyweight").value),
            hospital: parseInt(document.getElementById("hospital").value)
        };

        try {
            const response = await fetch(API_URL_Patient, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(patient)
            }); 

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`POST fehlgeschlagen: ${response.status} - ${errorText}`);
            }

            alert("Patient wurde hinzugefügt.");
            await fetchPatients();
        } catch (error) {
            console.error("Fehler in addPatient():", error);
            alert("Patient konnte nicht gespeichert werden.");
        }
}