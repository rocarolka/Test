import { Component } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  data: SendData;
  minDate = {
    'year': 1900,
    'month': 1,
    'day': 1
  };
  isDateValid: boolean;

  constructor(private api: AppService) {
    this.data = new SendData();
  }
  public CheckDate(date: NgbDateStruct) {
    const age =  18;
    const mydate = new Date();
    const currdate = new Date();
    mydate.setFullYear(date.year, date.month - 1, date.day);
    currdate.setFullYear(currdate.getFullYear() - age);
    this.isDateValid = currdate < mydate;
    }

    public OnSubmit() {
this.api.Send(this.data).subscribe(() => {}, () => {console.log("error"); });
    }
}

export class SendData {
  firstName: string;
  lastName: string;
  email: string;
  dateOfBirth: NgbDateStruct;
}
