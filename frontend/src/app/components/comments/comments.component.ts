import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Comment } from 'src/app/models/comment.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { CommentService } from 'src/app/services/comment/comment.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  public loggedUser: User;
  constructor(private router: Router,
    private userService: UserService,
    private commentService: CommentService) {
    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  @Input() commentType: string;
  @Input() genericId: string;

  public comments: Comment[] = []

  ngOnChanges() {
    this.loadComments();
  }

  async ngOnInit() {
    if (this.commentType == "meetings") {
      await this.loadComments();
    } else {
      alert('Não foi possível carregar os comentários!');
    }
  }

  async loadComments() {
    if (this.commentType == "meetings") {
      this.comments = await this.commentService.getMeetingComments(this.genericId);
    }
  }

  async addComment(txtComment) {

    if (txtComment.value != '') {
      let comment: Comment = new Comment();

      if (this.commentType == "meetings") {
        comment.customerMeetingId = this.genericId;
      }

      comment.date = new Date();
      comment.text = txtComment.value;
      comment.user = this.loggedUser;
      comment.userId = this.loggedUser.id;

      await this.commentService.add(comment);
    }

    txtComment.value = '';
    this.loadComments();
  }
}
