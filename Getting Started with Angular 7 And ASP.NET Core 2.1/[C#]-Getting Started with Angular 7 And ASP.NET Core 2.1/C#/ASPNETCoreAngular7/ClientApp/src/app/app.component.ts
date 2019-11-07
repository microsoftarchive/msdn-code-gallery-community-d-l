import { Component } from '@angular/core';

import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Welcome to Shanu Angular 7 Web page'; 
  datetime = Date.now();

  incrementValue: number[] = [];

  decrementValue: number[] = [];
  constructor() {
    for (let index = 1; index <= 200; index++) {
      this.incrementValue.push(index);
    }

    for (let int1 = 400; int1 >= 201; int1--) {
      this.decrementValue.push(int1);
    }
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.decrementValue, event.previousIndex, event.currentIndex);
  }
}
