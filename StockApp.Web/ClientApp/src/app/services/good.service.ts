import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IGood} from "../models/good/good.model";
import {environment} from "../../environments/environment";
import {PaginationResponse} from "../models/pagination-response.model";
import {ICreateGood} from "../models/good/create-good.model";

@Injectable({
  providedIn: 'root'
})
export class GoodService {
  protected baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {

  }


  getList (count: number, page: number) {
    return this.http.get<PaginationResponse<IGood>>(this.baseUrl + '/api/Good/GetGoods?count=' + count + '&page=' + page, {});
  }

  create(good: ICreateGood){
    return this.http.post(this.baseUrl + '/api/Good/Add', good);
  }
}
