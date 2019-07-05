import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Payment} from '../shared/models/Payments';
import { PaymentService } from '../shared/services/payment.service';
import { EventEmitter, ChangeDetectorRef } from '@angular/core';
import {Router} from '@angular/router';
import {LoginComponent} from '../login/login.component';
import { Userorder } from '../shared/models/Userorder';
import {CheckoutComponent} from '../checkout/checkout.component';
import {UserorderService} from '../shared/services/userorder.service';
import { Ordercreate} from '../shared/models/Ordercreate';


@Component({
  selector: 'app-addpaypage',
  templateUrl: './addpaypage.component.html',
  styleUrls: ['../../assets/css/login.css']
})
export class AddpaypageComponent implements OnInit {
  userfname: string;
  userlname: string;
  useremail: string;
  private newpay:Payment;
  private neworder: Userorder;
  private oc:Ordercreate;
  constructor(private fb: FormBuilder, private paymentService: PaymentService,private router:Router,private userorderService :UserorderService) {
    
   }

  checkoutForm = this.fb.group({
    cardnumber: ['', Validators.required],
    bankname: ['',Validators.required],
    holdname: ['',Validators.required],
    expiredate: ['',Validators.required],
    cvs:['',Validators.required]

  });
  ngOnInit() {
    this.useremail = sessionStorage.getItem("useremail")
    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")

    console.log("yes");
    console.log(this.orderlist);
    for(let element of this.orderlist){
      //this.neworder=new Userorder(this.currentdate,this.user.email,element.ID,1,this.checkoutForm.value.cardnumber);
      console.log("1")
    }
  }
  user = LoginComponent.searchResult[0];
  orderlist = CheckoutComponent.orderlist;
  
  onSubmit() {
    console.log("here");
    this.oc=new Ordercreate(this.useremail,this.checkoutForm.value.cardnumber);
    console.log(this.oc);
    this.userorderService.callServer(this.oc)
    
     .subscribe(data=>console.log("succeeded,result = "+ data),(err)=>console.error("Faild!"+err));
    console.log();
    
    
    this.newpay=new Payment(this.checkoutForm.value.cardnumber,this.checkoutForm.value.bankname,this.checkoutForm.value.holdname,this.checkoutForm.value.expiredate,this.checkoutForm.value.cvs);
        console.log(this.newpay);
        this.paymentService.callServer(this.newpay)
        .subscribe(data=>console.log("succeeded,result = " + data + this.newpay),
        (err)=>console.error("Failed!"+err));
        //this.router.navigate(['/login']);
    
        // this.router.navigate(['/successpay']);
         this.router.navigate(['/game']);
          }
      
        
}
