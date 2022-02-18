﻿using System.Collections.Generic;

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
            Stack<int> result = null;
           
           int act=sourceStack.Pop;
           int max=act;
           result.Push(-1);
           while(sourceStack.Count>0)
           {
               act=sourceStack.Pop;
               if(act>max)
               {
                   max=act;
                   result.Push(-1);
               }
               else{
                   result.Push(max);

               }
           }
            
            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = null;
            int act=0;
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
                else if(act % act == 0)
                {
                    result.Add(act,EValueType.Prime);
                }
            }

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        { int cant=0;
        EValueType act=null;
            Dictionary<int, EValueType>.ValueCollection valueColl = sourceDict.Values;
        for(int i=0;i<valueColl.Count;i++)
        {
          act=valueColl[i];
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
            Dictionary<string, string>.KeyCollection keyColl =sourceDict.Keys;
           for (int i = 0; i < keyColl.Count; i++) {
    for (int j = 0; j < keyColl.Count - 1; j++) {
        if (keyColl[j] < keyColl[j + 1]) {
            temp = keyColl[j + 1];
            keyColl[j + 1] = keyColl[j];
            keyColl[j] = temp;
        }
    }
}
 int[] listafinal= new int[];
 for(int i;i<keyColl.Count;i++)
 {
     listafinal[i]=keyColl[i];
 }
          result= FillDictionaryFromSource(listafinal);
            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = null;
            Queue<Ticket> colaPayment = new Queue<Ticket>();
             Queue<Ticket> colaSubscription = new Queue<Ticket>();
               Queue<Ticket> colaCancelation = new Queue<Ticket>();

               for(int i=0;i<sourceList.Count;i++)
               {
                   Ticket act=sourceList[i];
                   if(act.Equals("Payment"))
                   {
                         colaPayment.Enqueue(act);
                   }
                   else if(act.Equals("Subscription"))
                   {
                       colaSubscription.Enqueue(act);
                   }
                   else
                   {
                       colaCancelation.Enqueue(act);
                   }
               }
                result[0]= colaPayment;
                result[1]= colaSubscription;
                result[2]=colaCancelation;
            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;
           Queue<Ticket> clon=targetQueue;
           ticket muestra= clon.Dequeue;
           if(ticket.Equals("Payment") || ticket.Equals("Subscription") || ticket.Equals("Cancellation"))
           {
            if(muestra.Equals(ticket))
            {
                targetQueue.Enqueue(ticket);
                result=true;
            }
            else{
                result=false;
            }
           }
           else{
               result=false;
           }

            return result;
        }        
               }
        }

