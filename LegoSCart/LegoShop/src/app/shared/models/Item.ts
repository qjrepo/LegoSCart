import{Lego} from '../models/Lego'
export class Items{

   Lego1: Lego;
   
   Count1 : number;

   constructor (private lego1 :Lego,private count1: number  ){

       this.Lego1 = lego1;
       this.Count1 = count1;


   }

}

