import { Component, OnInit } from '@angular/core';
import {ItemService}  from '../shared/services/item.service';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Lego } from '../shared/models/Lego';
import {LoginComponent} from '../login/login.component';
import{Checkout} from '../shared/models/Checkout';
import {Router} from '@angular/router';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.sass']
})
export class HomepageComponent implements OnInit {
  
  private items: Array<Lego> = [];
  public item1: Lego;public item2: Lego;public item3: Lego;
  public item4: Lego;public item5: Lego;public item6: Lego;
  public item7: Lego;public item8: Lego;public item9: Lego;
  public item10: Lego;
  public i : number;


  constructor(private fb: FormBuilder, private itemService: ItemService,private router:Router) { }
  userfname: string;
  userlname: string;
  useremail: string;
  async ngOnInit() {
    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")
    this.useremail = sessionStorage.getItem("useremail")
    this.email = this.useremail;
    await this.getItems();
    console.log(LoginComponent.searchResult[0]);
    
    
  }
  itemFormatter = (item: Lego) => item.Name;
  //  getItems() {
  //   this.itemService.getItems()
  //    .subscribe(items => this.items = items);
  
  //user=this.LoginComponent.user; 
  // }
  async getItems() {
    const promise = new Promise((resolve, reject) => {
      this.itemService.getItems()
        .toPromise()
        .then(
          res => { // Success
            
            this.items = res;
            resolve();
            console.log(this.items[2].Name)
            
            this.item1= this.items[0] ;this.item2= this.items[1] ;this.item3= this.items[2] ;
            this.item4= this.items[3] ;this.item5= this.items[4] ;this.item6= this.items[5] ;
            this.item7= this.items[6] ;this.item8= this.items[7] ;this.item9= this.items[8] ;
            this.item10= this.items[9] ;

            
          },
          
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
   user = LoginComponent.searchResult[0];
  
  
  // Number(t) {
  //   var item;
  //   this.items.forEach(i => { if (i.ID == t) item = i; });
   
  //   this.item1 = item;
  // }//how to use it in view?

   
logout(){

  sessionStorage.removeItem("useremail")
  sessionStorage.removeItem("userfirstname")
  sessionStorage.removeItem("userlastname")
  this.router.navigate(['/login']);

}


}
