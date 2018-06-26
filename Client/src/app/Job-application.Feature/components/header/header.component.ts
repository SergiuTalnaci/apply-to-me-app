import { Component, OnInit, Input } from '@angular/core';
import { QuestionsService } from '../../services/questions.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input() titleText : string;
  constructor(private questionService: QuestionsService) { }

  ngOnInit() {
    this.questionService.getValues().subscribe(x => { 
      console.log(x);
    });
  }

}
