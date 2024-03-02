INSERT INTO ANAGRAFICA (cognome, nome, indirizzo, citta, CAP, CF) VALUES
('Rossi', 'Mario', 'Via Roma 1', 'Roma', 00100, 'RSSMRA85M01H501Z'),
('Bianchi', 'Luca', 'Via Milano 2', 'Milano', 20100, 'BNCLCU82P12F205Z'),
('Verdi', 'Giulia', 'Via Napoli 3', 'Napoli', 80100, 'VRDGIL88E42G376K'),
('Gialli', 'Sofia', 'Via Torino 4', 'Torino', 10100, 'GLLSFI90M50Z210X'),
('Neri', 'Marco', 'Via Firenze 5', 'Firenze', 50100, 'NRMRCU93H01D612W'),
('Viola', 'Elena', 'Via Palermo 6', 'Palermo', 90100, 'VLOELN95E66A662H'),
('Celesti', 'Andrea', 'Via Genova 7', 'Genova', 16100, 'CLSNDR98M08L736J'),
('Arancioni', 'Rita', 'Via Bologna 8', 'Bologna', 40100, 'RNCRTT01H42B612G'),
('Marroni', 'Fabio', 'Via Venezia 9', 'Venezia', 30100, 'MRNFBA04L25Z404U'),
('Rosa', 'Alessia', 'Via Catania 10', 'Catania', 95100, 'RSALSA87M41C351F');


INSERT INTO TIPOVIOLAZIONE (descrizione) VALUES
('Eccesso di velocità'),
('Sosta vietata'),
('Guida senza casco'),
('Manutenzione veicolo inadeguata'),
('Uso del telefono senza vivavoce'),
('Attraversamento pedonale fuori dalle strisce'),
('Sorpasso in zona vietata'),
('Guida in stato di ebbrezza'),
('Mancata precedenza a veicoli di emergenza'),
('Violazione dei limiti di rumore');


INSERT INTO VERBALE (dataViolazione, indirizzoViolazione, nominativoAgente, dataTrascrizioneVerbale, importo, decurtamentoPunti, idAnagrafica, idViolazione) VALUES
('2024-01-01', 'Via Roma 1', 'Agente Bianchi', '2024-01-02 10:00:00', 100, 2, 1, 1),
('2024-01-03', 'Via Milano 2', 'Agente Rossi', '2024-01-04 11:00:00', 150, 3, 2, 2),
('2024-01-05', 'Via Napoli 3', 'Agente Verdi', '2024-01-06 12:00:00', 200, 1, 3, 3),
('2024-01-07', 'Via Torino 4', 'Agente Gialli', '2024-01-08 13:00:00', 250, 2, 4, 4),
('2024-01-09', 'Via Firenze 5', 'Agente Neri', '2024-01-10 14:00:00', 300, 3, 5, 5),
('2024-01-11', 'Via Palermo 6', 'Agente Viola', '2024-01-12 15:00:00', 350, 1, 6, 6),
('2024-01-13', 'Via Genova 7', 'Agente Celesti', '2024-01-14 16:00:00', 400, 2, 7, 7),
('2024-01-15', 'Via Bologna 8', 'Agente Arancioni', '2024-01-16 17:00:00', 450, 3, 8, 8),
('2024-01-17', 'Via Venezia 9', 'Agente Marroni', '2024-01-18 18:00:00', 500, 1, 9, 9),
('2024-01-19', 'Via Catania 10', 'Agente Rosa', '2024-01-20 19:00:00', 550, 2, 10, 10);



