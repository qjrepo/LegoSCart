import { Component, OnInit } from '@angular/core';
import { Lego } from '../shared/models/Lego';
import { User} from '../shared/models/Users';
import { FormGroup, FormControl, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import {ItemService}  from '../shared/services/item.service';
import { 
  Router, NavigationStart, NavigationCancel, NavigationEnd 
} from '@angular/router';
import {LoginComponent} from '../login/login.component';
import { stringify } from 'querystring';
import { element } from '@angular/core/src/render3';
import {Items} from '../shared/models/Item';
import { LegoshopComponent } from '../legoshop/legoshop.component';
import { groupBy } from 'rxjs/operators';
import { ɵangular_packages_platform_browser_platform_browser_b } from '@angular/platform-browser';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import{Checkout} from '../shared/models/Checkout';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ["../../assets/css/cartstyle.css"]
})
export class CheckoutComponent implements OnInit {
  loading;
  countMap = new Map<Lego,number> ();

  testMap : Map<number, number>= new Map<number, number>();

   public checkoutlist1: Array<Checkout>=[] ;
    public checkout1 : Checkout;
    public total: number = 0;
    public  items: Array<Checkout>=[] ;
    dict :Array<number>=[];
    private count: number =0
    private sample1: Array<Lego>=[] ;
    private compressed: Array<Items>=[];
    private a: Items;
    private u: User;
    private removelego: Lego;
    
    // 
    private b : [Lego, number]

    constructor( private itemService: ItemService,private router: Router ) 
   {  this.loading = true;
      
    
       }
   userfname: string;
    userlname: string;
  private useremail : string;
  async ngOnInit() {

    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")
   this.useremail=sessionStorage.getItem("useremail")
   this.email = this.useremail;
    console.log("geeg")
    await this.getItems();
    //   await this.getItems();
      console.log("geeg")
      console.log(this.items)

    for(var element of this.items){
      if(element.userEmail == this.useremail){
        this.checkoutlist1.push(element);
        if(element.list.ID==1){
          element.list.Age="https://stachhh.neocities.org/b1.jpg";
          this.removelego=element.list;
        }else if(element.list.ID==2){
          element.list.Age="https://stachhh.neocities.org/joker.jpg";
          this.removelego=element.list;
        }else if(element.list.ID==3){
          element.list.Age="https://stachhh.neocities.org/assembly.jpg";
          this.removelego=element.list;
        }else if (element.list.ID==4){
          element.list.Age="https://stachhh.neocities.org/taji1.jpg";
          this.removelego=element.list;
        }else if (element.list.ID==5){
          element.list.Age="https://stachhh.neocities.org/gts.jpg";
          this.removelego=element.list;
        }else if(element.list.ID==6){
          element.list.Age="https://stachhh.neocities.org/disney.jpg";
          this.removelego=element.list;
        }else if(element.list.ID==7){
          element.list.Age="https://stachhh.neocities.org/bujadi.jpg";
          this.removelego=element.list;
        }else if(element.list.ID==8){
          element.list.Age="https://stachhh.neocities.org/hogwart1.jpg";
          this.removelego=element.list;
        }else{
          element.list.Age="https://stachhh.neocities.org/milleFalon.jpg";
          this.removelego=element.list;
        }
        console.log(this.checkoutlist1.length)
      }
    }
     
    
     //this.orderlist = this.checkoutlist1;
     
     console.log(this.checkoutlist1.length)
     this.Total();

    this.u = LoginComponent.searchResult[0];
   
   }


   user = LoginComponent.searchResult[0];
  
   async getItems() {
    const promise = new Promise((resolve, reject) => {
      this.itemService.getCheckout()
        .toPromise()
        .then(
          res => { // Success
            
            this.items = res;
            resolve();
            console.log("used")
          
          },
        );
    });
    await promise;
  }
      
  public static orderlist =[];

 


  private countt:number;
  price : Array<number>= []
  Total(){

    for (let element of this.checkoutlist1){
       this.countt= element.list.Price*element.count;
       this.price.push(this.countt);
       console.log(this.checkoutlist1.length)

    }

    console.log(this.price.length)
    
    for(var i=0; i< this.price.length;i++ ){
        this.total += this.price[i];
    }
    console.log(this.total)
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
        
        // window.location.reload();
        setTimeout(() => {
        
          window.location.reload();  
        }, 2000);
        
        // this.u = this.user;
      //  await  this.router.navigate(['/checkout']);
      //  window.location.reload();
      }
      
      table(){
        this.checkoutlist1.forEach(element => {



          
        });


      


      }
      public mes: any;
      test:string;
 removeOne(){
        console.log(this.removelego)
        this.checkout1 = new Checkout(this.useremail,this.removelego,1)
        
        this.itemService.callserver4(this.checkout1)
        .subscribe(data=> console.log("worked" + data + this.checkout1)),
        (err) => console.error("Failed" +err);
        // this.router.navigate(['/detail1']);
        this.test=ItemService.deletestring;
       
        alert("remove successfully! Please keep shopping :) ");
        setTimeout(() => {
        
        window.location.reload();  
      }, 2000);
       
        // this.router.navigate(['/homepage']);
        
        
        
     }



//  }
  //  Output(){
  //   this.checkoutlist1.forEach(element =>{
  //      var dict = groupBy(element => element)    
        // if(this.countMap.has(element)){
          
          // this.count = this.checkoutlist1.filter(i =>i == element).length;
          // this.countMap.set(this.checkoutlist1.filter(i =>i == element).length, element)
        // }
        // else {

          // this.countMap.set(element,1)

        // }
  //   })
  //  }
   
//    Output3(){
     
//       this.sample1 = this.checkoutlist1;
//       for (var i=0; i< this.checkoutlist1.length;i++){
//                  for(var j=0; j< this.sample1.length; j++){
//                   if(this.checkoutlist1[i] == this.sample1[j])
//                   {
//                       this.count++;
//                       // delete this.sample1[j];
//                       this.sample1.splice(j,1)
//                       console.log(this.sample1.length)
//                       console.log(this.count)
//                   }
//               }
//                if (this.count > 0 ){
//   //               //  this.a =  new Items ;{this.a.Lego1 = this.checkoutlist1[i],this.a.Count1=count};
//                 this.a = new Items(this.checkoutlist1[i], this.count)
//                 this.compressed.push(this.a);
//            }
//            }
//             console.log(this.compressed)
//             console.log(this.compressed.length)
//  }


        


        
      //  copy : Array<Lego>= this.checkoutlist1.slice(0);
      //  myCount :number = 0;	
      //  i : number
      //  w: number
      //  compressArray() {
      //       for ( this.i = 0; this.i < this.checkoutlist1.length; this.i++) {
           
              
      //         for (this.w = 0; this.w < this.copy.length; this.w++) {
                
      //           if (this.checkoutlist1[this.i].ID == this.copy[this.w].ID) {
                 
      //             this.myCount++;
                  
      //             console.log(this.myCount)
      //             this.copy.splice(this.w,1);
      //           }
      //          console.log(this.myCount)
      //         } 
              
      //         if (this.myCount > 0) {
                
      //           var a = new Items(this.checkoutlist1[this.i],this.myCount);
      //           this.compressed.push(a); 
      //         }

      //       }

      //       console.log(this.compressed)
      //       // return this.compressed;
      //     };
      
      
    // myFunction() {
    // alert("lll");
    // }
    
}