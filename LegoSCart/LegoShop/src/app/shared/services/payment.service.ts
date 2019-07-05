import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Constants } from '../../../app/app.constants';

import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandlerService } from '../../shared/services/error-handler.service';
import { Payment } from '../models/Payments';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor( private http: HttpClient,
    
    private errorHandleService: ErrorHandlerService) { }

  callServer(data: Payment): Observable<any>{
    console.log(data.Expiredate)
    
    return this.http.post('https://asplego.azurewebsites.net/api/payments/Post02',data);
    //return this.http.post('http://localhost:5000/api/payments/Post02',data);
    
    
}
}


