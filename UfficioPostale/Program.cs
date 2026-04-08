namespace UfficioPostale
{
    internal class Program
    {
        static void Accettazione(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria)
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
        static void Servizio(List<string> clientiSpedizioni, List<string> clientiSpid, List<string> clientiFinanziaria)
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
                clientiSpedizioni.RemoveAt(0);
                
            }
            else if(servizio == 2 && clientiFinanziaria.Count == 0)
            {
                Console.WriteLine("non c'è nessuno da servire");
            }
            else if(servizio == 2 && clientiFinanziaria.Count != 0)
            {
                Console.WriteLine("Hai servito il cliente " + clientiFinanziaria[0] + " della lista finanziaria");
                clientiFinanziaria.RemoveAt(0);
               
            }
            else if(servizio == 3 && clientiSpid.Count == 0)
            {
                Console.WriteLine("non c'è nessuno da servire");
            }
            else if(servizio == 3 && clientiSpid.Count != 0)
            {
                Console.WriteLine("Hai servito il cliente " + clientiSpid[0] + " della lista spid");
                clientiSpid.RemoveAt(0);
                
            }
        }

        static void Main(string[] args)
        {
            List<string> clientiSpedizioni = new List<string>();
            List<string> clientiSpid = new List<string>();
            List<string> clientiFinanziaria = new List<string>();
            bool chiusura = false;

            while(chiusura == false)
            {
                Console.WriteLine("scegli un'opzione: ");
                Console.WriteLine("1) Accetta cliente");
                Console.WriteLine("2) Servi cliente");
                Console.WriteLine("3) Chiusura");
                int scelta = Convert.ToInt32(Console.ReadLine());

                if(scelta == 1)
                {
                    Accettazione(clientiSpedizioni, clientiSpid, clientiFinanziaria);
                }
                else if(scelta == 2) 
                {
                    Servizio(clientiSpedizioni,clientiSpid,clientiFinanziaria);
                }
            }
        }
    }
}
