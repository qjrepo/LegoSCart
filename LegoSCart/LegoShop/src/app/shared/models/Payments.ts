export class Payment{
      
    Cardnumber: number;
    Bankname: string;
    Holdname: string;
    Expiredate: string;
    CVS: number;
   
    constructor(cardnumber:number,bankname:string,holdname:string,expiredate:string,cvs:number){
        this.Cardnumber = cardnumber;
        this.Bankname = bankname;
        this.Holdname = holdname;
        this.Expiredate = expiredate;
        this.CVS=cvs;

  }
    
}
