import { Injectable ,EventEmitter} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Constants } from '../../../app/app.constants';
import { Lego } from '../../shared/models/Lego';
import { catchError, map, tap } from 'rxjs/operators';
import { forEach } from '@angular/router/src/utils/collection';
import { Checkout } from '../models/Checkout';
import { Try } from '../models/Try';



@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private order: Array<string> = [];
  private items: Array<Lego> = [];
  private item: Lego;
  private test: Checkout;
  newDataAdded=new EventEmitter<string>();
  
  constructor(
    private http: HttpClient,
  ) { }
  getItems(): Observable<Lego[]> {
    const uri = decodeURIComponent(
`${Constants.locationAPIUrl}/api/legos?apikey=${Constants.apiKey}`);
    return this.http.get<Lego[]>(uri)
      .pipe(
tap(_ => console.log('fetched items')),
// catchError(this.errorHandleService.handleError('getItems', [])) 
);
 }
 callserver(data: Checkout): Observable<any>{
  
  console.log(data.list);
  return this.http.post("https://asplego.azurewebsites.net/api/checkout/Post01", data)
  
  //return this.http.post('http://localhost:5000/api/checkout/Post01', data)




 }

 public static deletestring:string;
callserver2(data: Checkout): Observable<any>{
  ItemService.deletestring="remove successful!";
  console.log(data)
  return this.http.post("https://asplego.azurewebsites.net/api/check/Remove2", data)
  //return this.http.post("http://localhost:5000/api/check/Remove2", data)


}
 
 getCheckout(): Observable<Checkout[]> {
  const uri = decodeURIComponent(
`${Constants.locationAPIUrl}/api/checkout?apikey=${Constants.apiKey}`);
  console.log("stephere")
  return this.http.get<Checkout[]>(uri)
    .pipe(
tap(_ => console.log('fetched itemsssssssssssss')),
// catchError(this.errorHandleService.handleError('getItems', [])) 
);

}

callserver4(data: Checkout): Observable<any>{
  
  console.log(data.list);
  return this.http.post("https://asplego.azurewebsites.net/api/removeone/Remove1", data)
  
  //return this.http.post('http://localhost:5000/api/removeone/Remove1', data)



 }



 

}
