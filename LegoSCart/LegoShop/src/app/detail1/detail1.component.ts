import { Component, OnInit } from '@angular/core';
import { Lego } from '../shared/models/Lego';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import {ItemService}  from '../shared/services/item.service';
//import {OrderService}  from '../shared/services/order.service';
import { HttpClient } from '@angular/common/http';
import {LoginComponent} from '../login/login.component';
import{Checkout} from '../shared/models/Checkout';
import {Router} from '@angular/router';
@Component({
  selector: 'app-detail1',
  templateUrl: './detail1.component.html',
  styleUrls: ['../../assets/css/detail.scss'],
  
})
export class Detail1Component implements OnInit {
  userfname: string;
  userlname: string;
  useremail: string;
  public checkouts:Array<Checkout>=[];
  public checkout1:Checkout;
  public items: Array<Lego> = [];
  public item1: Lego;
  public  static order: Array<Lego> = [];
  public static itemname: Array<string> = [];
  public static itemprice: Array<number> = [];

  public  static count11 : number = 0  ;
  public errorMessage: string;
  constructor(public fb: FormBuilder, 
  public itemService: ItemService, 
  public http: HttpClient,
  public router:Router
  ) { }

  async ngOnInit() {
//     this.orderService.newSubject.subscribe(
//       data => console.log(data)
//  )

this.useremail = sessionStorage.getItem("useremail")
this.userfname = sessionStorage.getItem("userfirstname")
this.userlname = sessionStorage.getItem("userlastname")
this.email = this.useremail;
    console.log(Detail1Component.order.length)
    await this.getItems();
    
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
            console.log(this.items[0].Name)
            
            this.item1= this.items[0] ;
            console.log(this.item1)
          },
          err => {
            console.error(err);
            this.errorMessage = err;
            reject(err);
          }
        );
    });
    await promise;
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
  add(i: number){
    this.checkout1=new Checkout(this.useremail,this.item1,1);
   
    console.log(this.item1)
    alert("add successful");
    this.itemService.callserver(this.checkout1)
    .subscribe(data=> console.log("worked" + data + this.checkout1)),
    (err) => console.error("Failed" +err)
    this.router.navigate(['/detail1']);
    console.log("done!")
    // this.items.forEach(element => {
    //      if (element.ID == i){
    //           this.item1 = element;
    //      }
    // });
    // Detail1Component.order.push(this.item1)
    // Detail1Component.itemname.push(this.item1.Name)
    // Detail1Component.itemprice.push(this.item1.Price)
    // // this.order.push(this.item1)
    // console.log(Detail1Component.order[0])
    // Detail1Component.count11 +=1;

    //this.http.post("http://localhost:5000/api/checkout", this.item1).subscribe((data) => {});
    //console.log(data => this.http.post("http://localhost:5000/api/checkout",this.items).subscribe((data) => {}))
 }

}
