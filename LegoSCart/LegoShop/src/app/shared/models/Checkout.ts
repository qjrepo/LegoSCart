import {Lego} from './Lego';

export class Checkout{
    userEmail:string;
    list:Lego;
    count:number;

    constructor(userEmail1:string, list1:Lego,count1:number){
        this.userEmail=userEmail1;
        this.list=list1;
        this.count=count1;

    }
}