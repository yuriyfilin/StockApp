import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IAcceptance} from "../models/acceptance/acceptance.model";
import {environment} from "../../environments/environment";
import {PaginationResponse} from "../models/pagination-response.model";
import {ICreateGood} from "../models/good/create-good.model";
import {ICreateAcceptance} from "../models/acceptance/create-acceptance.model";

@Injectable({
  providedIn: 'root'
})
export class AcceptanceService {
  protected baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {

  }


  getList (count: number, page: number) {
    return this.http.get<PaginationResponse<IAcceptance>>(this.baseUrl + '/api/Acceptance/GetAcceptances?count=' + count + '&page=' + page, {});
  }

  create(acceptance: ICreateAcceptance){
    return this.http.post(this.baseUrl + '/api/Acceptance/Add', acceptance);
  }
}
