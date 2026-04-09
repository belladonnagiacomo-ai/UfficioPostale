using System.Runtime.CompilerServices;
using System.Security.Permissions;
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
        static void Servizio(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria, ref int servitoSped,ref int servitoFin,ref int servitoSpid, ref int sped, ref int fin, ref int spid)
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
                sped--;
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
                fin--;
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
                spid--;
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
        static void chiusuraSpid(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria)
        {
            Console.WriteLine("La coda Spid e chiusa e tutte le persone in coda verrano spostate nella coda Finanziaria");
            for(int i = 0;i < clientiSpid.Count;i++)
            {
                clientiFinanziaria.Add(clientiSpid[i]);
                clientiSpid.RemoveAt(i);
            }
        }
        static void PuliziaS(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria)
        {
            char[] alfabeto = { 'a', 'b', 'c', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            bool trovato = false;
            for(int i = clientiSpedizioni.Count - 1;i >= 0;i--)
            {
                for(int j = 0; j < clientiSpedizioni[i].Length; j++)
                {
                    for(int k = 0; k < alfabeto.Length; k++)
                    {
                        if (clientiSpedizioni[i][j] != alfabeto[k])
                        {
                            trovato = true;
                           
                        }
                    }
                }
                if (trovato == true)
                {
                    clientiSpedizioni.Remove(clientiSpedizioni[i]);
                }
                trovato = false;
            
            }
            for (int i = clientiFinanziaria.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < clientiFinanziaria[i].Length; j++)
                {
                    for (int k = 0; k < alfabeto.Length; k++)
                    {
                        if (clientiFinanziaria[i][j] != alfabeto[k])
                        {
                            trovato = true;

                        }
                    }
                }
                if (trovato == true)
                {
                    clientiFinanziaria.Remove(clientiFinanziaria[i]);
                }
                trovato = false;

            }
            for (int i = clientiSpid.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < clientiSpid[i].Length; j++)
                {
                    for (int k = 0; k < alfabeto.Length; k++)
                    {
                        if (clientiSpid[i][j] != alfabeto[k])
                        {
                            trovato = true;

                        }
                    }
                }
                if (trovato == true)
                {
                    clientiSpid.Remove(clientiSpid[i]);
                }
                trovato = false;

            }


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
                Console.WriteLine("5) chiusura Spid");
                Console.WriteLine("6) Pulizia sistema");
                int scelta = Convert.ToInt32(Console.ReadLine());

                if(scelta == 1)
                {
                    Accettazione(clientiSpedizioni, clientiSpid, clientiFinanziaria, ref sped, ref fin, ref spid);
                }
                else if(scelta == 2) 
                {
                    Servizio(clientiSpedizioni,clientiSpid,clientiFinanziaria, ref servitoSped, ref servitoFin, ref servitoSpid, ref sped, ref fin, ref spid);
                }
                else if(scelta == 3)
                {
                    errore(clientiSpedizioni, clientiSpid, clientiFinanziaria);
                }
                else if (scelta == 4)
                {
                    panoramica(clientiSpedizioni, clientiSpid, clientiFinanziaria,ref sped,ref fin,ref spid,ref servitoSped,ref servitoFin,ref servitoSpid);
                }
                else if(scelta == 5)
                {
                    chiusuraSpid(clientiSpedizioni, clientiSpid, clientiFinanziaria);
                }
                else if(scelta == 6)
                {

                }
            }
        }
    }
}
