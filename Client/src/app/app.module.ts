import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from "./app.component";
import { MatButtonModule, MatCheckboxModule, MatFormFieldModule, MatSelectModule, MatTabsModule, MatCardModule, MatInputModule } from "@angular/material";
import { HeaderComponent } from './Job-application.Feature/components/header/header.component';
import { QuestionsService } from './Question-answer.Feature/services/questions.service';
import { HomeComponent } from './Question-answer.Feature/components/home/home.component';
import { OpeningsComponent } from './Job-application.Feature/components/openings/openings.component';
import { FormsModule } from "@angular/forms";
import { AnswersService } from "./Question-answer.Feature/services/answers.service";

@NgModule({
  declarations: [AppComponent, HeaderComponent, HomeComponent, OpeningsComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTabsModule,
    MatCardModule,
    MatInputModule
  ],
  providers: [QuestionsService, AnswersService],
  bootstrap: [AppComponent]
})
export class AppModule {}
