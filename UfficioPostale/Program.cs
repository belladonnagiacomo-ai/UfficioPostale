using System.Runtime.CompilerServices;
using System.Xml.XPath;

namespace UfficioPostale
{
    internal class Program
    {
        static void Accettazione(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria, ref int sped, ref int fin, ref int spid)
        {
            Console.WriteLine("Dimmi il tuo nome");
            Console.WriteLine();
            string nome = Console.ReadLine();
            Console.WriteLine("Dimmi quanti anni hai");
            int anni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("In quale coda vuoi andare: ");
            Console.WriteLine("1) Coda Spedizioni (Per pacchi e raccomandate)");
            Console.WriteLine("2) Coda Finanziaria (Per bollettini, prelievi, pensioni)");
            Console.WriteLine("3) Coda SPID (Per identità digitale)");
            int scelta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if(scelta == 1)
            {
                sped++;
               if(anni >= 65)
               {
                    clientiSpedizioni.Insert(clientiSpedizioni.Count / 2, nome);
                    foreach (string s in clientiSpedizioni)
                    {
                        Console.WriteLine("E stato aggiunto il cliente " + s + " alla lista spedizioni");
                    }

                }
                else
                {
                    clientiSpedizioni.Add(nome);
                    foreach (string s in clientiSpedizioni)
                    {
                        Console.WriteLine("E stato aggiunto il cliente " + s + " alla lista spedizioni");
                    }
                }
            }
            else if(scelta == 2)
            {
                fin++;
                if (anni >= 65)
                {
                    clientiFinanziaria.Insert(clientiFinanziaria.Count / 2, nome);
                    foreach (string f in clientiFinanziaria)
                    {
                        Console.WriteLine("E stato aggiunto il cliente " + f + " alla lista finanziaria");
                    }

                }
                else
                {
                    clientiFinanziaria.Add(nome);
                    foreach (string f in clientiFinanziaria)
                    {
                        Console.WriteLine("E stato aggiunto il cliente " + f + " alla lista finanziaria");
                    }
                }
            }
            else if(scelta == 3)
            {
                spid++;
                if (anni >= 65)
                {
                    clientiSpid.Insert(clientiSpid.Count / 2, nome);
                    foreach (string p in clientiSpid)
                    {
                        Console.WriteLine("E stato aggiunto il cliente " + p + " alla lista spid");
                    }

                }
                else
                {
                    clientiSpid.Add(nome);
                    foreach (string p in clientiSpid)
                    {
                        Console.WriteLine("E stato aggiunto il cliente " + p + " alla lista spid");
                    }
                }
            }
            
            
            

        }
        static void Servizio(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria, ref int servitoSped,ref int servitoFin,ref int servitoSpid)
        {
            Console.WriteLine("Quale settore vuoi servire");
            Console.WriteLine("1) Coda Spedizioni");
            Console.WriteLine("2) Coda Finanziaria");
            Console.WriteLine("3) Coda SPID");
            int servizio = Convert.ToInt32(Console.ReadLine());

            if(servizio == 1 && clientiSpedizioni.Count == 0)
            {
                Console.WriteLine("non c'è nessuno da servire");
            }
            else if(servizio == 1 && clientiSpedizioni.Count != 0)
            {
                Console.WriteLine("Hai servito il cliente " + clientiSpedizioni[0] + " della lista spedizioni");
                servitoSped++;
                clientiSpedizioni.RemoveAt(0);
                
            }
            else if(servizio == 2 && clientiFinanziaria.Count == 0)
            {
                Console.WriteLine("non c'è nessuno da servire");
            }
            else if(servizio == 2 && clientiFinanziaria.Count != 0)
            {
                Console.WriteLine("Hai servito il cliente " + clientiFinanziaria[0] + " della lista finanziaria");
                servitoFin++;
                clientiFinanziaria.RemoveAt(0);
               
            }
            else if(servizio == 3 && clientiSpid.Count == 0)
            {
                Console.WriteLine("non c'è nessuno da servire");
            }
            else if(servizio == 3 && clientiSpid.Count != 0)
            {
                Console.WriteLine("Hai servito il cliente " + clientiSpid[0] + " della lista spid");
                servitoSpid++;
                clientiSpid.RemoveAt(0);
                
            }
        }

        static void errore(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria)
        {
            Console.WriteLine("Quale cliente vuole trovare?");
            string nome = Console.ReadLine();
            for(int i = 0;i < clientiSpedizioni.Count;i++)
            {
                if (clientiSpedizioni[i] == nome)
                {
                    Console.WriteLine("Il cliente " + nome + " si trova nella coda spedizioni");
                    Console.WriteLine("Dove vuole spostare il cliente?");
                    Console.WriteLine("1) Lista Finanziaria");
                    Console.WriteLine("2) Lista Spid");
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    clientiSpedizioni.Remove(nome);
                    if(scelta == 1)
                    {
                        clientiFinanziaria.Add(nome);
                        return;
                    }
                    else
                    {
                        clientiSpid.Add(nome);
                        return;
                    }
                }
                
            }
            for (int i = 0; i < clientiFinanziaria.Count; i++)
            {
                if (clientiFinanziaria[i] == nome)
                {
                    Console.WriteLine("Il cliente " + nome + " si trova nella coda finanziaria");
                    Console.WriteLine("Dove vuole spostare il cliente?");
                    Console.WriteLine("1) Lista Spedizioni");
                    Console.WriteLine("2) Lista Spid");
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    clientiFinanziaria.Remove(nome);
                    if (scelta == 1)
                    {
                        clientiSpedizioni.Add(nome);
                        return;
                    }
                    else
                    {
                        clientiSpid.Add(nome);
                        return;
                    }
                }
                
            }
            for(int i = 0;i < clientiSpid.Count;i++) 
            {
                if (clientiSpid[i] == nome)
                {
                    Console.WriteLine("Il cliente " + nome + " si trova nella coda spid");
                    Console.WriteLine("Dove vuole spostare il cliente?");
                    Console.WriteLine("1) Lista Finanziaria");
                    Console.WriteLine("2) Lista Spedizioni");
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    clientiSpid.Remove(nome);
                    if (scelta == 1)
                    {
                        clientiFinanziaria.Add(nome);
                        return;
                    }
                    else
                    {
                        clientiSpedizioni.Add(nome);
                        return;
                    }
                }
               
            }

        }
        static void panoramica(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria, ref int sped, ref int fin, ref int spid, ref int servitoSped, ref int servitoFin, ref int servitoSpid)
        {
            Console.WriteLine("Persone in attesa nella coda spedizioni: " + sped);
            Console.WriteLine();
            Console.WriteLine("Persone in attesa nella coda finanziaria: " + fin);
            Console.WriteLine();
            Console.WriteLine("Persone in attesa nella coda spid: " + spid);
            Console.WriteLine();
            Console.WriteLine("Clienti in Spedizioni: ");
            foreach (string s  in clientiSpedizioni)
            {
                Console.WriteLine(s);
                Console.WriteLine("---------");
            }
            Console.WriteLine("Clienti in Finanziaria: ");
            foreach (string s in clientiFinanziaria)
            {
                Console.WriteLine(s);
                Console.WriteLine("---------");
            }
            Console.WriteLine("Clienti in Spid: ");
            foreach (string s in clientiSpid)
            {
                Console.WriteLine(s);
                Console.WriteLine("---------");
            }
            Console.WriteLine();

            Console.WriteLine("persone servite nella coda Spedizioni: " + servitoSped);
            Console.WriteLine();
            Console.WriteLine("persone servite nella coda Finanziaria: " + servitoFin);
            Console.WriteLine();
            Console.WriteLine("persone servite nella coda Spid: " + servitoSpid);
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            List<string> clientiSpedizioni = new List<string>();
            List<string> clientiSpid = new List<string>();
            List<string> clientiFinanziaria = new List<string>();
            bool chiusura = false;
            int spid = 0, sped = 0, fin = 0,servitoSped = 0, servitoFin = 0,servitoSpid = 0;

            while(chiusura == false)
            {
                Console.WriteLine("scegli un'opzione: ");
                Console.WriteLine("1) Accetta cliente");
                Console.WriteLine("2) Servi cliente");
                Console.WriteLine("3) Errore cliente");
                Console.WriteLine("4) Panoramica");
                int scelta = Convert.ToInt32(Console.ReadLine());

                if(scelta == 1)
                {
                    Accettazione(clientiSpedizioni, clientiSpid, clientiFinanziaria, ref sped, ref fin, ref spid);
                }
                else if(scelta == 2) 
                {
                    Servizio(clientiSpedizioni,clientiSpid,clientiFinanziaria, ref servitoSped, ref servitoFin, ref servitoSpid);
                }
                else if(scelta == 3)
                {
                    errore(clientiSpedizioni, clientiSpid, clientiFinanziaria);
                }
                else if (scelta == 4)
                {
                    panoramica(clientiSpedizioni, clientiSpid, clientiFinanziaria,ref sped,ref fin,ref spid,ref servitoSped,ref servitoFin,ref servitoSpid);
                }
            }
        }
    }
}
