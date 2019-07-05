import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Constants } from '../../../app/app.constants';
import { User } from '../../shared/models/Users';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandlerService } from '../../shared/services/error-handler.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

 
  
  constructor(
    private http: HttpClient,
    
    private errorHandleService: ErrorHandlerService) { }


  getItems(): Observable<User[]> {
    const uri = decodeURIComponent(
`${Constants.locationAPIUrl}/api/users?apikey=${Constants.apiKey}`);
    return this.http.get<User[]>(uri)
      .pipe(
tap(_ => console.log('fetched items')),
// catchError(this.errorHandleService.handleError('getItems', [])) 
);
  }

  // add_user(user){
  //   const uri = decodeURIComponent(
  //     `${Constants.locationAPIUrl}/api/users?apikey=${Constants.apiKey}`);
  //     return this.http.post<User[]>(uri)
  //     .pipe(
  //       tap(_ => console.log("fetched user")),
  //       catchError(this.errorHandleService.handleError('search_user', []))
  //       );
      

  // }

  search_user(userinfo) {
    const uri = decodeURIComponent(
      `${Constants.searchusersAPIUrl}` + userinfo);
    return this.http.get<User[]>(uri)
      .pipe(
      tap(_ => console.log("fetched user")),
      catchError(this.errorHandleService.handleError('search_user', []))
      );
    
  }



  callServer(data: User): Observable<any>{
       return this.http.post('https://asplego.azurewebsites.net/api/users/Post01',data);
       //return this.http.post('http://localhost:5000/api/users/Post01',data);
  }




}
