export class Userorder{
    Ordertime:string;
    Useraccount:string;
    LegoId: number;
    Quantity: number;
    Payaccount: number;

    constructor(ordertime:string,useracc:string,legoid:number,quantity:number,payacc:number){
        this.Ordertime=ordertime;
        this.Useraccount=useracc;
        this.LegoId=legoid;
        this.Quantity=quantity;
        this.Payaccount=payacc;
    }
}
