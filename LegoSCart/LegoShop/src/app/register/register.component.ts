import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { User} from '../shared/models/Users';
import { UsersService } from '../shared/services/users.service';
import { EventEmitter, ChangeDetectorRef } from '@angular/core';
import {Router} from '@angular/router';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../../assets/css/login.css']
})
export class RegisterComponent implements OnInit {

  private newuser:User;
  constructor(private fb: FormBuilder, private userService: UsersService,private router:Router) {
    
   }

  registerForm = this.fb.group({
    firstname: ['', Validators.required],
    lastname: ['',Validators.required],
    email: ['',Validators.required],
    password:['',Validators.required]

  });

  ngOnInit() {
    
  }

  onSubmit() {
this.newuser=new User(this.registerForm.value.firstname,this.registerForm.value.lastname,this.registerForm.value.email,this.registerForm.value.password);
    console.log(this.newuser);
    this.userService.callServer(this.newuser)
    .subscribe(data=>console.log("succeeded,result = " + data + this.newuser),
    (err)=>console.error("Failed!"+err));
    this.router.navigate(['/login']);
      }
      

}
