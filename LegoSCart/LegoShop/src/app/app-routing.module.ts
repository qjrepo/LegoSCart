import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LegoshopComponent}  from './legoshop/legoshop.component';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {HomepageComponent}  from './homepage/homepage.component';
import {Detail1Component} from './detail1/detail1.component';
import {Detail2Component} from './detail2/detail2.component';
import {Detail3Component} from './detail3/detail3.component';
import {Detail4Component} from './detail4/detail4.component';
import {Detail5Component} from './detail5/detail5.component';
import {Detail6Component} from './detail6/detail6.component';
import {Detail7Component} from './detail7/detail7.component';
import {Detail8Component} from './detail8/detail8.component';
import {Detail9Component} from './detail9/detail9.component';
import { AddpaypageComponent } from './addpaypage/addpaypage.component';
import { SuccesspayComponent } from './successpay/successpay.component';
import { CheckoutComponent } from './checkout/checkout.component';
import {ViewhistoryComponent} from './viewhistory/viewhistory.component';
import {GameComponent}  from './game/game.component'
import { Checkout2Component } from './checkout2/checkout2.component';
const routes: Routes = [
   { path: '', redirectTo: 'legoshop', pathMatch: 'full' },
   { path: 'login', redirectTo: 'login', pathMatch: 'full' },
   { path:'register', redirectTo: 'register', pathMatch: 'full'},
   { path: 'homepage', redirectTo: 'homepage', pathMatch: 'full'},
   { path: 'detail1', redirectTo: 'detail1', pathMatch: 'full'},
   { path: 'detail2', redirectTo: 'detail2', pathMatch: 'full'},
   { path: 'detail3', redirectTo: 'detail3', pathMatch: 'full'},
   { path: 'detail4', redirectTo: 'detail4', pathMatch: 'full'},
   { path: 'detail5', redirectTo: 'detail5', pathMatch: 'full'},
   { path: 'detail6', redirectTo: 'detail6', pathMatch: 'full'},
   { path: 'detail7', redirectTo: 'detail7', pathMatch: 'full'},
   { path: 'detail8', redirectTo: 'detail8', pathMatch: 'full'},
   { path: 'detail9', redirectTo: 'detail9', pathMatch: 'full'},
   { path: 'game', redirectTo: 'game', pathMatch: 'full'},
   { path: 'checkout2', redirectTo: 'checkout2', pathMatch: 'full'},
   { path: 'legoshop', component: LegoshopComponent },
   { path: 'login', component: LoginComponent },
   { path: 'register', component: RegisterComponent},
   { path: 'homepage' , component: HomepageComponent},
   { path: 'detail1' , component: Detail1Component},
   { path: 'detail2' , component: Detail2Component},
   { path: 'detail3' , component: Detail3Component},
   { path: 'detail4' , component: Detail4Component},
   { path: 'detail5' , component: Detail5Component},
   { path: 'detail6' , component: Detail6Component},
   { path: 'detail7' , component: Detail7Component},
   { path: 'detail8' , component: Detail8Component},
   { path: 'detail9' , component: Detail9Component},
   { path: 'addpaypage' , component: AddpaypageComponent},
   { path: 'successpay' , component: SuccesspayComponent},
   { path: 'checkout' , component: CheckoutComponent},
   {path: 'viewhistory', component: ViewhistoryComponent},
   {path: 'game', component: GameComponent},
   {path: 'checkout2', component: Checkout2Component}
  
  
  ]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
