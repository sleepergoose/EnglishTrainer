import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpInternalService {
  private _basicUrl: string = environment.apiUrl;
  private _headers = new HttpHeaders();

  constructor(private _http: HttpClient) { }

  public getHeaders(): HttpHeaders {
    return this._headers;
  }

  public getRequest<T>(url: string, httpParams?: any): Observable<T> {
    return this._http.get<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
  }

  public postRequest<T>(url: string, payload: object): Observable<T> {
    return this._http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
  }

  public putRequest<T>(url: string, payload: object): Observable<T> {
    return this._http.put<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
  }

  public deleteRequest<T>(url: string, httpParams?: any): Observable<T> {
    return this._http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
  }

  public buildUrl(url: string): string {
    if (url.startsWith('http://') || url.startsWith('https://')) {
      return url;
    }
    return this._basicUrl + url;
  }
}
