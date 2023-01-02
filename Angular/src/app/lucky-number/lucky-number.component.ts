import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-lucky-number',
  templateUrl: './lucky-number.component.html'
})
export class LuckyNumberComponent {
  public luckyNumberResult: string | undefined;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    var url = baseUrl + 'luckynumber';
    http.get<number>(url).subscribe(result => {
      this.luckyNumberResult = result.toString();
    }, error => console.error(error));
  }
}