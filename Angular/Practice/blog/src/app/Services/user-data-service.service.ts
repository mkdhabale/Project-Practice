import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
interface dT{
  name:string,
  id:number
}
@Injectable({
  providedIn: 'root'
})
export class UserDataServiceService {


  constructor(private httpRO:HttpClient) { }

  getData()
  {
    const url = 'http://localhost:3000/contacts';

    const httpHeaders = new HttpHeaders();
    httpHeaders.append('content-type', 'application/json');
   return this.httpRO.get(url);
  }
  
  createData(jBody)
  {
    const url = 'http://localhost:3000/contacts';

    const httpHeaders = new HttpHeaders();
    httpHeaders.append('content-type', 'application/json');
   return this.httpRO.post(url, jBody, {headers: httpHeaders});
  }

  updateData(id, jBody)
  {
    const url = 'http://localhost:3000/contacts/'+ id;

    const httpHeaders = new HttpHeaders();
    httpHeaders.append('content-type', 'application/json');
   return this.httpRO.put(url, jBody, {headers: httpHeaders});
  }

  deleteData(id)
  {
    const url = 'http://localhost:3000/contacts/'+ id;

    const httpHeaders = new HttpHeaders();
    httpHeaders.append('content-type', 'application/json');
    return this.httpRO.delete(url, {headers: httpHeaders});
  }
}
