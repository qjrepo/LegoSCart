import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.sass']
})
export class GameComponent implements OnInit {
  userfname: string;
  userlname: string;
  useremail: string;
  
  constructor( private router: Router) { }
 
  ngOnInit() {
    this.useremail = sessionStorage.getItem("useremail")
    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")
    setTimeout(() => {
      this.router.navigate(['/successpay']);
      
  }, 12000);
    
    
    // this.router.navigate(['/successpay']);
  }


  go(){

    this.router.navigate(['/successpay']);
  }
   restart(){
    console.log("clicked")
    location.reload;
   }

}