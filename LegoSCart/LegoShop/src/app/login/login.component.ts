import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { User} from '../shared/models/Users';
import { UsersService } from '../shared/services/users.service';
import { EventEmitter, ChangeDetectorRef } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../assets/css/login.css']
})


export class LoginComponent implements OnInit {

  //private accname: string;
 // private pwd: string;
  

  profileForm = this.fb.group({
    accountName: ['', Validators.required],
    password: ['',Validators.required]
  });



accname = this.profileForm.value.accountName;

  onSubmit() {
    //alert(this.profileForm.value.accountName + this.profileForm.value.password)
    if(LoginComponent.searchResult[0]==null){
      
      alert('the username or password are not correct!');
    }else {
     sessionStorage.setItem("useremail", LoginComponent.searchResult[0].email)
     sessionStorage.setItem("userfirstname", LoginComponent.searchResult[0].firstname)
     sessionStorage.setItem("userlastname", LoginComponent.searchResult[0].lastname)
     this.router.navigate(['/homepage']);

    } //added
    //alert(this.searchResult[0].firstname + this.searchResult[0].lastname);
    console.log(LoginComponent.searchResult[0]);
    this.user2 = LoginComponent.searchResult[0];
  }

  loginuser = LoginComponent.searchResult[0]

  searchTerm: FormControl = new FormControl();

   public static searchResult = []

  private loginForm: FormGroup;
  public user: Array<User> = [];
  private user1: User;
  private user2: User;

  constructor(private fb: FormBuilder, private userService: UsersService, private router:Router) {
    this.profileForm.valueChanges
      .subscribe(data => {
        this.userService.search_user(data.accountName+data.password).subscribe(response => {
          LoginComponent.searchResult = response
        })
      })
    
  }

  ngOnInit() {
   // this.loginForm = this.buildForm();
    this.getItems();
  }


  
  async getItems() {
    const promise = new Promise((resolve, reject) => {
      this.userService.getItems()
        .toPromise()
        .then(
          res => { // Success
            this.user= res;
            resolve();
            console.log(this.user[0].Email);
            
            this.user1= this.user[0] ;
          },
        );
    });
    await promise;
  }
 


}
