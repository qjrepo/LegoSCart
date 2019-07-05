import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Constants } from '../../../app/app.constants';

import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandlerService } from '../../shared/services/error-handler.service';
import { Ordercreate } from '../models/Ordercreate';
import { Userorder } from '../models/Userorder';

@Injectable({
  providedIn: 'root'
})
export class UserorderService {

  constructor(private http: HttpClient,
    
    private errorHandleService: ErrorHandlerService) { }

    callServer(data: Ordercreate): Observable<any>{
      return this.http.post('https://asplego.azurewebsites.net/api/legos/Post02',data);
       //return this.http.post('http://localhost:5000/api/legos/Post02',data);
    }

    search_user(userinfo) {
      const uri = decodeURIComponent(
        `${Constants.searchusersAPIUrl}` + userinfo);
      return this.http.get<Userorder[]>(uri)
        .pipe(
        tap(_ => console.log("fetched user")),
        catchError(this.errorHandleService.handleError('search_order', []))
        );
      
    }

    getOrder(): Observable<Userorder[]> {
      const uri = decodeURIComponent(
    `${Constants.locationAPIUrl}/api/userorder?apikey=${Constants.apiKey}`);
      console.log("stephere")
      return this.http.get<Userorder[]>(uri)
        .pipe(
    tap(_ => console.log('fetched itemsssssssssssss')),
    // catchError(this.errorHandleService.handleError('getItems', [])) 
    );
      
}
}
