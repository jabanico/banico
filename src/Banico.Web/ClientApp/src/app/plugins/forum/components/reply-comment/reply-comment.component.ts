import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { ReplyComment } from '../../entities/reply-comment';
import { ReplyCommentService } from '../../services/reply-comment.service';

@Component({
  selector: 'app-reply-comment',
  templateUrl: './reply-comment.component.html',
  styleUrls: ['./reply-comment.component.scss']
})
export class ReplyCommentComponent {
  public replyComment: ReplyComment;
  private _id: string;
  public isEdit: boolean;

  constructor(
    private replyCommentService: ReplyCommentService
    ) {
  }

  @Input()
  set id(id: string) {
    this._id = id;
    this.replyCommentService.get(id)
    .subscribe(replyComment => this.set(replyComment));
  }

  private set(replyComment: ReplyComment) {
    this.replyComment = replyComment;
    this.replyCommentService.setReplyCommentUser(replyComment);
    this.isEdit = false;
  }

  public edit() {
    this.isEdit = true;
  }

  public onSave(text: string) {
    this.replyComment.text = text;
    this.isEdit = false;
  }

  public onCancel() {
    this.isEdit = false;
  }
}
