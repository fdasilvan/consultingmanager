import { Component, OnInit } from '@angular/core';
//noinspection TypeScriptCheckImport,TypeScriptCheckImport
import Player from "@vimeo/player";
import { CustomerTask } from 'src/app/models/customertask.model';
import { TaskContent } from 'src/app/models/taskcontent.model';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {

  constructor() { }

  public player: Player;
  public task: CustomerTask;
  public title: string;
  public body: string;
  public taskContent: TaskContent[];
  public currentContent: TaskContent;
  public currentPage: number;
  public showVideoPlayer: boolean;
  public showBody: boolean;

  ngOnInit() {
    this.loadContent();
  }

  loadContent() {
    // TODO: Refatorar a busca da tarefa com urgência!!
    this.task = <CustomerTask>JSON.parse(window.localStorage.getItem('task'));
    console.log(this.task);
    if (this.task && this.task.modelTask) {
      this.taskContent = this.task.modelTask.taskContent.sort((a, b) => a.pageNumber - b.pageNumber);
      let container = document.getElementById('content-container');

      if (this.taskContent.length > 0) {
        this.currentContent = this.taskContent[0];
        this.currentPage = 0;
        container.style.display = "block";
        this.title = this.currentContent.title;
        this.body = this.currentContent.body;
        this.loadVideo();
      } else {
        container.style.display = "none";
      }
    }
  }

  loadVideo() {
    this.showVideoPlayer = this.currentContent.videoUrl != '';
    let iframe = document.getElementById('videoPlayer');

    if (iframe && this.showVideoPlayer) {
      iframe.attributes['src'].value = this.currentContent.videoUrl;
      iframe.parentElement.parentElement.style.display = "block";
      this.player = new Player(iframe);
    } else {
      iframe.parentElement.parentElement.style.display = "none";
    }
  }

  previousContent() {
    if (this.currentPage > 0) {
      this.currentPage--;
      this.currentContent = this.taskContent[this.currentPage];
      this.title = this.currentContent.title;
      this.body = this.currentContent.body;
      this.loadVideo();
    }
  }

  nextContent() {
    if (this.currentPage < this.taskContent.length) {
      this.currentPage++;
      this.currentContent = this.taskContent[this.currentPage];
      this.title = this.currentContent.title;
      this.body = this.currentContent.body;
      this.loadVideo();
    }
  }
}
