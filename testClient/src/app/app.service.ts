import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { SendData } from './app.component';
import { environment } from '../environments/environment';

@Injectable()
export class AppService {
  private headers: Headers;
  private feedbackUrl: string;
  constructor(private _http: Http) {
    this.feedbackUrl = `${environment.apiUrl}/feedback`;
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Accept', 'application/json');
  }

  public Send = (data: SendData): Observable<any> => {
    const toAdd = JSON.stringify(data);
    return this._http.post(this.feedbackUrl, toAdd, { headers: this.headers });
  }
}
