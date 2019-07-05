import { Component, OnInit } from '@angular/core';
import { Lego } from '../shared/models/Lego';
import {ItemService} from '../shared/services/item.service';
import {Detail1Component} from '../detail1/detail1.component';
import {LoginComponent} from '../login/login.component';
import{Checkout} from '../shared/models/Checkout';
@Component({
  selector: 'app-detail2',
  templateUrl: './detail2.component.html',
  styleUrls: ['../../assets/css/detail.scss'],
  
})
export class Detail2Component implements OnInit {
  public checkouts:Array<Checkout>=[];
  public checkout1:Checkout;
  public items: Array<Lego> = [];
  public item2: Lego;
  public i :number;
  public static count12 : number = 0  ;
  userfname: string;
  userlname: string;
  useremail: string;
  constructor(public itemService: ItemService
    ) { 

  
  }
  
   async ngOnInit() {
     
    this.useremail = sessionStorage.getItem("useremail")
    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")
    this.email = this.useremail;
    
    await this.getItems();
   
  }
  email: string;
  object: Checkout;
  lego : Lego;
  
  emptyCart: Array<Lego>=[]
  clearCart(){
    console.log("entjjjjjkkkkkkjkjhlkjhkhjlkjhered")
    this.object = new Checkout(this.email, this.lego, 1)
    this.itemService.callserver2(this.object)
    .subscribe(data=> console.log("worked" + data + this.email))
    
  //  await  this.router.navigate(['/checkout']);
  }
   user = LoginComponent.searchResult[0];
  async getItems() {
    const promise = new Promise((resolve, reject) => {
      this.itemService.getItems()
        .toPromise()
        .then(
          res => { // Success
            
            this.items = res;
            resolve();
            console.log(this.items[1].Name)
            
            this.item2= this.items[1] ;
            
            
            
          },
          
        );
    });
    await promise;
  }

  add(i: number){
    this.checkout1=new Checkout(this.useremail,this.item2,1);
    alert("add successful");
    this.itemService.callserver(this.checkout1)
    .subscribe(data=> console.log("worked" + data + this.item2)),
    (err) => console.error("Failed" +err)
  }
}
