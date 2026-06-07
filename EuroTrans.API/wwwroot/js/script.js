const API_URL = '/api/candidates';

async function fetchMatches() {
        const response = await fetch(API_URL);
        const data = await response.json();
        const listContainer = document.getElementById('candidates-list');
        listContainer.innerHTML = '';

        data.forEach(match => {
            const listItem = document.createElement('li');
            listItem.className = 'match-item';

            listItem.innerHTML = `
                        <div>
                            <span class="patient-info">
                                Patient: ${match.recipientPatient.firstname} ${match.recipientPatient.lastname}
                            </span>
                            <span class="badge">Blutgruppe: ${match.recipientPatient.bloodType}</span>
                        </div>
                        <div class="heart-info">
                            Empfängt Spenderorgan: <strong>Herz-ID ${match.donorHeart.id}</strong> 
                            <span class="badge" style="background:#fef3c7; color:#b45309;">Spender-BG: ${match.donorHeart.bloodType}</span>
                        </div>
                    `;

            listContainer.appendChild(listItem);
        });
}

fetchMatches();