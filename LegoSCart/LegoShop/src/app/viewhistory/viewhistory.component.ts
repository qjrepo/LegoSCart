import { Component, OnInit } from '@angular/core';
import { Lego } from '../shared/models/Lego';
import { User} from '../shared/models/Users';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import {UserorderService}  from '../shared/services/userorder.service';
import { 
  Router, NavigationStart, NavigationCancel, NavigationEnd 
} from '@angular/router';
import {LoginComponent} from '../login/login.component';
import { Userorder } from '../shared/models/Userorder';
@Component({
  selector: 'app-viewhistory',
  templateUrl: './viewhistory.component.html',
  styleUrls: ["../../assets/css/cartstyle.css"]
})
export class ViewhistoryComponent implements OnInit {
  loading;
  countMap = new Map<Lego,number> ();

  testMap : Map<number, number>= new Map<number, number>();
  userfname: string;
  userlname: string;
  useremail: string;
   public checkoutlist1: Array<Userorder>=[] ;
   private user1: User;
 

    public  items: Array<Userorder>=[] ;

    dict :Array<number>=[];
   
    
    // 
    private b : [Lego, number]

    constructor( private userorderService: UserorderService,private router: Router ) 
   {  this.loading = true;
      
    
       }
       user = LoginComponent.searchResult[0];  
  async ngOnInit() {
    console.log("111");
    this.useremail = sessionStorage.getItem("useremail")
    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")
    await this.getItems();
    //   await this.getItems();
      console.log("geeg")
      console.log(this.items)
      console.log(this.useremail)
    for(var element of this.items){
      if(element.Useraccount == this.useremail){
        this.checkoutlist1.push(element)
        console.log(element.LegoId);
        if(element.LegoId==1){
          element.Useraccount="Big Ben";
        }else if(element.LegoId==2){
          element.Useraccount="The Joker™ Manor";
        }else if (element.LegoId==3){
          element.Useraccount="Assembly Square";
        }else if(element.LegoId==4){
          element.Useraccount="Taj Mahal";
        }else if(element.LegoId==5){
          element.Useraccount="Porsche 911 GT3 RS";
        }else if(element.LegoId==6){
          element.Useraccount="The Disney Castle";
        }else if(element.LegoId==7){
          element.Useraccount="Bugatti Chiron";
        }else if(element.LegoId==8){
          element.Useraccount="Hogwarts™ Castle";
        }else if(element.LegoId==9){
          element.Useraccount="Millennium Falcon™";
        }
        console.log(this.checkoutlist1.length)
      }else{
        this.checkoutlist1=[];
        console.log("not found")
      }
    }}



  
   async getItems() {
    const promise = new Promise((resolve, reject) => {
      this.userorderService.getOrder()
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

      
      table(){
        this.checkoutlist1.forEach(element => {



          
        });





      }
}