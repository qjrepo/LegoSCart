import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatToolbarModule} from '@angular/material';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LegoshopComponent } from './legoshop/legoshop.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { LoginComponent } from './login/login.component';
// import {AlertModule} from 'ngx-bootstrap';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { HomepageComponent } from './homepage/homepage.component';
import {HttpClientModule} from '@angular/common/http';
import { Detail1Component } from './detail1/detail1.component';
import { Detail2Component } from './detail2/detail2.component';
import { Detail3Component } from './detail3/detail3.component';
import { Detail4Component } from './detail4/detail4.component';
import { Detail5Component } from './detail5/detail5.component';
import { Detail6Component } from './detail6/detail6.component';
import { Detail7Component } from './detail7/detail7.component';
import { Detail8Component } from './detail8/detail8.component';
import { Detail9Component } from './detail9/detail9.component';
import { AddpaypageComponent } from './addpaypage/addpaypage.component';
import { SuccesspayComponent } from './successpay/successpay.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ViewhistoryComponent } from './viewhistory/viewhistory.component';
import { GameComponent } from './game/game.component';
import { Checkout2Component } from './checkout2/checkout2.component';
@NgModule({
  declarations: [
    AppComponent,
    LegoshopComponent,
    LoginComponent,
    RegisterComponent,
    HomepageComponent,
    Detail1Component,
    Detail2Component,
    Detail3Component,
    Detail4Component,
    Detail5Component,
    Detail6Component,
    Detail7Component,
    Detail8Component,
    Detail9Component,
    AddpaypageComponent,
    SuccesspayComponent,
    CheckoutComponent,
    ViewhistoryComponent,
    GameComponent,
    Checkout2Component
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule ,
    AppRoutingModule,
    CarouselModule.forRoot(),
    HttpClientModule,
    MatToolbarModule
    
    // AlertModule.forRoot(),// added for bootstrap4
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
