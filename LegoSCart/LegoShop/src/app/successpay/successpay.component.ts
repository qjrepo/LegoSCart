import { Component, OnInit } from '@angular/core';
import {LoginComponent} from '../login/login.component';

@Component({
  selector: 'app-successpay',
  templateUrl: './successpay.component.html',
  styleUrls: ['../../assets/css/success.css']
})
export class SuccesspayComponent implements OnInit {

  constructor() { }
  userfname: string;
  userlname: string;
  useremail: string;
  ngOnInit() {
    this.userfname = sessionStorage.getItem("userfirstname")
    this.userlname = sessionStorage.getItem("userlastname")
  }
  user = LoginComponent.searchResult[0];
}
