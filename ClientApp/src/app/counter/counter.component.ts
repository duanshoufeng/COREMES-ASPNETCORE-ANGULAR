import { Component } from "@angular/core";

@Component({
  selector: "coremes-counter",
  templateUrl: "./counter.component.html",
})
export class CounterComponent {
  currentCount = 0;
  title = "COREMES";

  courses = ["course1", "course2", "course3"];

  incrementCounter() {
    this.currentCount++;
  }
}
