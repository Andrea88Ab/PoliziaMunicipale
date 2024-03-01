using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;


namespace PoliziaMunicipale.Models
{
    public static class DB
    {
        public static void AggiungiTrasgressore(IConfiguration configuration, string surname, string name, string address, string city, int cap, string cf)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            

                try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [ANAGRAFICA] (cognome, nome, indirizzo, citta, CAP, CF) VALUES(@surname, @name, @address, @city, @cap,@cf)";
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("city", city);
                cmd.Parameters.AddWithValue("cap", cap);
                cmd.Parameters.AddWithValue("cf", cf);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static void AggiungiViolazione(IConfiguration configuration, string description)
        {
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))

                try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [TIPOVIOLAZIONE] (descrizione) VALUES(@description)";
                cmd.Parameters.AddWithValue("description", description);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static List<Trasgressore> getAllTrasgressori(IConfiguration configuration)
        {
            List<Trasgressore> trasgressori = new List<Trasgressore>();

            // Recupera la stringa di connessione utilizzando IConfiguration
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ANAGRAFICA", conn);
                conn.Open();

                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Trasgressore t = new Trasgressore
                        {
                            Id = Convert.ToInt32(sqlDataReader["idAnagrafica"]),
                            Surname = sqlDataReader["cognome"].ToString(),
                            Name = sqlDataReader["nome"].ToString(),
                            Address = sqlDataReader["indirizzo"].ToString(),
                            City = sqlDataReader["citta"].ToString(),
                            CAP = Convert.ToInt32(sqlDataReader["CAP"]),
                            CF = sqlDataReader["CF"].ToString(),
                        };
                        trasgressori.Add(t);
                    }
                }
            }

            return trasgressori;
        }
    

    public static List<Violazione> getAllViolazioni(IConfiguration configuration)
    {
        List<Violazione> violazioni = new List<Violazione>();

        // Utilizza IConfiguration per ottenere la stringa di connessione
        string connectionString = configuration.GetConnectionString("ConnectionStringDB");
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TIPOVIOLAZIONE", conn);
            conn.Open();

            using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    Violazione v = new Violazione
                    {
                        Id = Convert.ToInt32(sqlDataReader["idViolazione"]),
                        Description = sqlDataReader["descrizione"].ToString(),
                    };
                    violazioni.Add(v);
                }
            }
        }

        return violazioni;
    }
        public static List<Verbale> getAllVerbali(IConfiguration configuration)
        {
            List<Verbale> verbali = new List<Verbale>();

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VERBALE", conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Verbale v = new Verbale
                            {
                                Id = Convert.ToInt32(sqlDataReader["idVerbale"]),
                                DataViolazione = Convert.ToDateTime(sqlDataReader["dataviolazione"]),
                                IndirizzoViolazione = sqlDataReader["indirizzoViolazione"].ToString(),
                                Agente = sqlDataReader["nominativoAgente"].ToString(),
                                DataVerbale = Convert.ToDateTime(sqlDataReader["dataTrascrizioneVerbale"]),
                                Importo = Convert.ToDouble(sqlDataReader["importo"]),
                                PuntiTolti = Convert.ToInt32(sqlDataReader["decurtamentoPunti"]),
                                IdTrasgressore = Convert.ToInt32(sqlDataReader["idAnagrafica"]),
                                IdViolazione = Convert.ToInt32(sqlDataReader["idViolazione"]),
                            };
                            verbali.Add(v);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione delle eccezioni o logging
                    throw; // Rilancia l'eccezione o gestiscila come necessario
                }
                finally
                {
                    conn.Close();
                }
            }

            return verbali;
        }

        public static void AggiungiVerbale(IConfiguration configuration, DateTime dataViolazione, string address, string agent, DateTime dataVerbale, double amount, int points, int idT, int idV)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [VERBALE] (dataViolazione, IndirizzoViolazione, nominativoAgente, dataTrascrizioneVerbale, importo, decurtamentoPunti, idAnagrafica, idViolazione) VALUES (@dataViolazione, @address, @agent, @dataVerbale, @amount, @points, @idT, @idV)", conn))
                    {
                        cmd.Parameters.AddWithValue("@dataViolazione", dataViolazione);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@agent", agent);
                        cmd.Parameters.AddWithValue("@dataVerbale", dataVerbale);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@points", points);
                        cmd.Parameters.AddWithValue("@idT", idT);
                        cmd.Parameters.AddWithValue("@idV", idV);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // Oppure gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static List<VerbaliByT> getCountVerbaliByTrasgressore(IConfiguration configuration)
        {
            List<VerbaliByT> verbaliByT = new List<VerbaliByT>();

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ANAGRAFICA.idAnagrafica, cognome, nome, COUNT(*) AS TotVerbali FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.idAnagrafica = VERBALE.idAnagrafica GROUP BY ANAGRAFICA.idAnagrafica, cognome, nome", conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            verbaliByT.Add(new VerbaliByT
                            {
                                IdT = Convert.ToInt32(sqlDataReader["idAnagrafica"]),
                                Surname = sqlDataReader["cognome"].ToString(),
                                Name = sqlDataReader["nome"].ToString(),
                                TotVerbali = Convert.ToInt32(sqlDataReader["TotVerbali"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione eccezioni o logging
                    throw; // o gestisci come necessario
                }
                finally
                {
                    conn.Close();
                }
            }

            return verbaliByT;
        }

        public static List<PuntiByT> getPuntiByTrasgressore(IConfiguration configuration)
        {
            List<PuntiByT> puntiByT = new List<PuntiByT>();

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ANAGRAFICA.idAnagrafica, cognome, nome, SUM(decurtamentoPunti) AS TotPuntiPersi FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.idAnagrafica = VERBALE.idAnagrafica GROUP BY ANAGRAFICA.idAnagrafica, cognome, nome", conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            puntiByT.Add(new PuntiByT
                            {
                                IdT = Convert.ToInt32(sqlDataReader["idAnagrafica"]),
                                Surname = sqlDataReader["cognome"].ToString(),
                                Name = sqlDataReader["nome"].ToString(),
                                TotPuntiPersi = Convert.ToInt32(sqlDataReader["TotPuntiPersi"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }

            return puntiByT;
        }

        public static List<AnMag10Punti> getTrasgressoriMag10Punti(IConfiguration configuration)
        {
            List<AnMag10Punti> anMag10 = new List<AnMag10Punti>();

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT cognome, nome, dataViolazione, importo, decurtamentoPunti FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.idAnagrafica = VERBALE.idAnagrafica WHERE decurtamentoPunti > 10", conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            AnMag10Punti a = new AnMag10Punti
                            {
                                Surname = sqlDataReader["cognome"].ToString(),
                                Name = sqlDataReader["nome"].ToString(),
                                DataViolazione = Convert.ToDateTime(sqlDataReader["dataViolazione"]),
                                Amount = Convert.ToDouble(sqlDataReader["importo"]),
                                PuntiPersi = Convert.ToInt32(sqlDataReader["decurtamentoPunti"])
                            };
                            anMag10.Add(a);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione delle eccezioni o logging
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }

            return anMag10;
        }

        public static List<ImportoMag400> getImportoMag400(IConfiguration configuration)
        {
            List<ImportoMag400> amountMag400 = new List<ImportoMag400>();

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT cognome, nome, dataViolazione, importo, decurtamentoPunti FROM VERBALE INNER JOIN ANAGRAFICA ON ANAGRAFICA.idAnagrafica = VERBALE.idAnagrafica WHERE importo > 400", conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            amountMag400.Add(new ImportoMag400
                            {
                                Surname = sqlDataReader["cognome"].ToString(),
                                Name = sqlDataReader["nome"].ToString(),
                                DataViolazione = Convert.ToDateTime(sqlDataReader["dataViolazione"]),
                                Amount = Convert.ToDouble(sqlDataReader["importo"]),
                                Points = Convert.ToInt32(sqlDataReader["decurtamentoPunti"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione delle eccezioni o logging
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }

            return amountMag400;
        }

        public static Trasgressore getTrasgressoreById(IConfiguration configuration, int id)
        {
            Trasgressore t = null; // Inizializza a null per gestire il caso in cui il trasgressore non venga trovato

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ANAGRAFICA WHERE idAnagrafica = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Usa if invece di while se ti aspetti un solo risultato
                        {
                            t = new Trasgressore
                            {
                                Id = Convert.ToInt32(sqlDataReader["idAnagrafica"]),
                                Surname = sqlDataReader["cognome"].ToString(),
                                Name = sqlDataReader["nome"].ToString(),
                                Address = sqlDataReader["indirizzo"].ToString(),
                                City = sqlDataReader["citta"].ToString(),
                                CAP = Convert.ToInt32(sqlDataReader["CAP"]),
                                CF = sqlDataReader["CF"].ToString(),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione delle eccezioni o logging
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }

            return t;
        }

        public static Violazione getViolazioneById(IConfiguration configuration, int id)
        {
            Violazione v = null; // Inizializza a null per gestire il caso in cui la violazione non venga trovata

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TIPOVIOLAZIONE WHERE idViolazione = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Usa if invece di while se ti aspetti un solo risultato
                        {
                            v = new Violazione
                            {
                                Id = Convert.ToInt32(sqlDataReader["idViolazione"]),
                                Description = sqlDataReader["descrizione"].ToString(),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione delle eccezioni o logging
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }

            return v;
        }
        public static Verbale getVerbaleById(IConfiguration configuration, int id)
        {
            Verbale v = null; // Inizializza a null per gestire il caso in cui il verbale non venga trovato

            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VERBALE WHERE idVerbale = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Usa if invece di while se ti aspetti un solo risultato
                        {
                            v = new Verbale
                            {
                                Id = Convert.ToInt32(sqlDataReader["idVerbale"]),
                                DataViolazione = Convert.ToDateTime(sqlDataReader["dataViolazione"]),
                                IndirizzoViolazione = sqlDataReader["indirizzoViolazione"].ToString(),
                                Agente = sqlDataReader["nominativoAgente"].ToString(),
                                DataVerbale = Convert.ToDateTime(sqlDataReader["dataTrascrizioneVerbale"]),
                                Importo = Convert.ToDouble(sqlDataReader["importo"]),
                                PuntiTolti = Convert.ToInt32(sqlDataReader["decurtamentoPunti"]),
                                IdTrasgressore = Convert.ToInt32(sqlDataReader["idAnagrafica"]),
                                IdViolazione = Convert.ToInt32(sqlDataReader["idViolazione"]),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gestione delle eccezioni o logging
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }

            return v;
        }
        public static void UpdateTrasgressore(IConfiguration configuration, int id, string surname, string name, string address, string city, int cap, string cf)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE ANAGRAFICA SET cognome=@surname, nome=@name, indirizzo=@address, citta=@city, CAP=@cap, CF=@cf WHERE idAnagrafica = @id", conn))
                    {
                        // Utilizza il metodo Add con un oggetto SqlParameter per una gestione più precisa dei tipi
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@surname", surname));
                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@address", address));
                        cmd.Parameters.Add(new SqlParameter("@city", city));
                        cmd.Parameters.Add(new SqlParameter("@cap", cap));
                        cmd.Parameters.Add(new SqlParameter("@cf", cf));

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // o gestisci l'errore in modo appropriato
                }
            }
        }

        public static void RemoveTrasgressore(IConfiguration configuration, int id)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ANAGRAFICA WHERE idAnagrafica = @id", conn))
                    {
                        // Utilizzo di AddWithValue per semplicità, ma considera l'uso di Add per una maggiore precisione del tipo
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void UpdateViolazione(IConfiguration configuration, int id, string description)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE TIPOVIOLAZIONE SET descrizione = @description WHERE idViolazione = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void RemoveViolazione(IConfiguration configuration, int id)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TIPOVIOLAZIONE WHERE idViolazione = @id", conn))
                    {
                        // Uso di AddWithValue, considerare l'uso di Add per una maggiore precisione dei tipi
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // o gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void UpdateVerbale(IConfiguration configuration, int id, DateTime dataV, string address, string agent, DateTime dataT, double amount, int points, int idT, int idV)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE VERBALE SET dataViolazione=@dataV, indirizzoViolazione=@address, nominativoAgente=@agent, dataTrascrizioneVerbale=@dataT, importo=@amount, decurtamentoPunti=@points, idAnagrafica=@idT, idViolazione=@idV WHERE idVerbale = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@dataV", dataV);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@agent", agent);
                        cmd.Parameters.AddWithValue("@dataT", dataT);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@points", points);
                        cmd.Parameters.AddWithValue("@idT", idT);
                        cmd.Parameters.AddWithValue("@idV", idV);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // Oppure gestisci l'errore in modo appropriato
                }
            }
        }

        public static void RemoveVerbale(IConfiguration configuration, int id)
        {
            // Utilizza IConfiguration per ottenere la stringa di connessione
            string connectionString = configuration.GetConnectionString("ConnectionStringDB");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM VERBALE WHERE idVerbale = @id", conn))
                    {
                        // Utilizzo di AddWithValue per semplicità, ma considera l'uso di Add per una maggiore precisione dei tipi
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Considera di gestire l'eccezione o di registrare un log
                    throw; // Oppure gestisci l'errore in modo appropriato
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}