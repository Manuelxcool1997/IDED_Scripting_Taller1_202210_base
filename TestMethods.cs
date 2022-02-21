using System.Collections.Generic;
using System.Linq;
using System;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            Stack<int> result = new Stack<int>();
            List<int> lista = new List<int>();
           while(sourceStack.Count > 0)
            {
                lista.Add(sourceStack.Pop());
            }

            List<int> listreverse = Enumerable.Reverse(lista).ToList();

            for (int i = 0; i < listreverse.Count; i++)
            {
                bool con = false;
                for (int j = i + 1; j < listreverse.Count; j++)
                {
                    if (listreverse[i] < listreverse[j])
                    {
                        result.Push(listreverse[j]);
                        con = false;
                        break;
                    }
                    else
                    {
                        con = true;
                    }
                }
                if (con)
                {
                    result.Push(-1);
                }
            }


            result.Push(-1);


            for (int i = 0; i < listreverse.Count; i++)
            {
                Console.WriteLine(listreverse[i]);
            }







            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();
            int act =0;
            for(int i=0;i<sourceArr.Length;i++)
            {
                act=sourceArr[i];
                if(act % 2 ==0)
                {
                    result.Add(act, EValueType.Two);
                }
                else if(act % 3 == 0)
                {
                  result.Add(act, EValueType.Three);  
                }
                else if(act % 5 == 0)
                {
                    result.Add(act,EValueType.Five);
                }
                else if(act % 7 == 0)
                {
                    result.Add(act,EValueType.Seven);
                }
                else 
                {
                    result.Add(act,EValueType.Prime);
                }
            }

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        { int cant=0;
        EValueType act= 0;
            Dictionary<int, EValueType>.ValueCollection valueColl = sourceDict.Values;
            List<EValueType> lista = new List<EValueType>();
            lista.AddRange(valueColl);
            for (int i=0;i<valueColl.Count;i++)
        {
          act=lista[i];
          if(act.Equals(type))
          {
              cant++;
          }
        }
           
            return cant;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = null;
            Dictionary<int, EValueType>.KeyCollection keyColl = sourceDict.Keys;
            List<int> lista = new List<int>();
            lista.AddRange(keyColl);
            int temp = 0;
            for (int i = 0; i < lista.Count *3; i++)
            {
                for (int j = 0; j < lista.Count - 1; j++)
                {
                    if (lista[j] < lista[j + 1])
                    {
                        temp = lista[j + 1];
                        lista[j + 1] = lista[j];
                        lista[j] = temp;
                    }
                }
            }
            int[] listafinal = new int[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                
                listafinal[i] = lista[i];
            }

            result = FillDictionaryFromSource(listafinal);

            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result =  new Queue<Ticket>[3] ;
            Queue<Ticket> colaPayment = new Queue<Ticket>();
             Queue<Ticket> colaSubscription = new Queue<Ticket>();
               Queue<Ticket> colaCancelation = new Queue<Ticket>();
            List<Ticket> listapay = new List<Ticket>();
            List<Ticket> listasubs = new List<Ticket>();
            List<Ticket> listacan = new List<Ticket>();

            Ticket act = new Ticket();

               for (int i=0;i<sourceList.Count;i++)
               {
                    act=sourceList[i];
                   if(act.RequestType.Equals(Ticket.ERequestType.Payment))
                   {
                         listapay.Add(act);
                   }
                   else if(act.RequestType.Equals(Ticket.ERequestType.Subscription))
                   {
                      listasubs.Add(act);
                   }
                   else if(act.RequestType.Equals(Ticket.ERequestType.Cancellation))
                   {
                      listacan.Add(act);
                   }
               }
            
            for (int i = 0; i < listapay.Count ; i++)
            {
                Ticket temp; ;
                for (int j = 0; j < listapay.Count - 1; j++)
                {
                    if (listapay[j].Turn > listapay[j + 1].Turn)
                    {
                        temp = listapay[j + 1];
                        listapay[j + 1] = listapay[j];
                        listapay[j] = temp;
                    }
                }
            }
            for(int i = 0; i < listapay.Count ; i++)
            {
                colaPayment.Enqueue(listapay[i]);
            }
            for (int i = 0; i < listasubs.Count; i++)
            {
                Ticket temp; ;
                for (int j = 0; j < listasubs.Count - 1; j++)
                {
                    if (listasubs[j].Turn> listasubs[j + 1].Turn)
                    {
                        temp = listasubs[j + 1];
                        listasubs[j + 1] = listasubs[j];
                        listasubs[j] = temp;
                    }
                }
            }
            for (int i = 0; i < listasubs.Count; i++)
            {
                colaSubscription.Enqueue(listasubs[i]);
            }
            for (int i = 0; i < listapay.Count; i++)
            {
                Ticket temp; ;
                for (int j = 0; j < listacan.Count - 1; j++)
                {
                    if (listacan[j].Turn > listacan[j + 1].Turn)
                    {
                        temp = listacan[j + 1];
                        listacan[j + 1] = listacan[j];
                        listacan[j] = temp;
                    }
                }
            }
            for (int i = 0; i < listacan.Count; i++)
            {
                colaCancelation.Enqueue(listacan[i]);
            }
            Console.Write(colaPayment.Count);
            result[0] = colaPayment;
            result[1] = colaSubscription;
                result[2] = colaCancelation;
            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = true;
            bool cond = false;
            Queue<Ticket> clon = new Queue<Ticket>();
            Queue<Ticket> clon2 = new Queue<Ticket>();
            clon = targetQueue;
            clon2 = targetQueue;

            List<Ticket> lista = new List<Ticket>();
            while (clon.Count > 0)
            {
                lista.Add(clon.Dequeue());

            }
            Ticket.ERequestType hola = new Ticket.ERequestType();
            for (int i = 0; i < lista.Count; i++)
            {
                hola = lista[i].RequestType;
            }


            Console.Write(ticket.RequestType);
            Console.Write(ticket.Turn);
            if (ticket.RequestType.Equals(hola) && ticket.Turn < 100)
            {
                
                return true;
            }
            else
            {

                return false;
            }
               }

        }

