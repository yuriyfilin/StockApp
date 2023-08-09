import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from "../../environments/environment";
import {BaseResponse} from "../models/base-response.model";
import {IUnits} from "../models/units/units.model";

@Injectable({
  providedIn: 'root'
})
export class UnitsService {
  protected baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {

  }


  getList () {
    return this.http.get<BaseResponse<IUnits[]>>(this.baseUrl + '/api/Units/GetUnits', {});
  }
}
