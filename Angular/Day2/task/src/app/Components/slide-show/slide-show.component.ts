import { Component } from '@angular/core';

@Component({
  selector: 'app-slide-show',
  templateUrl: './slide-show.component.html',
  styleUrls: ['./slide-show.component.css']
})

export class SlideShowComponent {

    arr: string[] = ["assets/images/1.jpg", "assets/images/2.jpg", "assets/images/3.jpg",
                    "assets/images/4.jpg", "assets/images/5.jpg", "assets/images/6.jpg",
                    "assets/images/7.jpg", "assets/images/8.jpg"];

    imgSrc = this.arr[0];
    counter = 0;
    intervalId: number = 0;

    nxt() {
      this.counter++;
      if (this.counter >= this.arr.length) {
        this.counter = 7;
      }
      this.imgSrc = this.arr[this.counter];
    }

    prev() {
      this.counter--;
      if (this.counter < 0) {
        this.counter = 0;
      }
      this.imgSrc = this.arr[this.counter];
    }

    slide() {
      this.intervalId = setInterval(() => {
        this.imgSrc = this.arr[this.counter];
        this.counter++;
        if (this.counter >= this.arr.length) {
          this.counter = 0;
        }
      }, 500);
    }

    stop() {
      clearInterval(this.intervalId);
    }
}
