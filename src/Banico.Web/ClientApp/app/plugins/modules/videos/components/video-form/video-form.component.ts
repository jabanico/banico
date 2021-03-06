import { Component, OnInit, Inject } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AuthService } from "../../../../../shared/services/auth.service";
import { Video } from "../../entities/video";
import { VideosService } from "../../services/videos.service";

@Component({
  selector: "app-plugins-videos-channel-form",
  templateUrl: "./video-form.component.html",
  providers: [VideosService]
})
export class VideoFormComponent implements OnInit {
  public video: Video = new Video(null);
  private sub: any;
  public videoForm: FormGroup = this.fb.group({
    channelId: ["", Validators.required],
    url: ["", Validators.required],
    description: [""],
    order: [""]
  });

  public constructor(
    private videosService: VideosService,
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      var id = params["id"];
      if (id) {
        this.videosService.getVideo(id).subscribe(video => {
          this.setVideo(video);
        });
      }

      var channelId = params["channelId"];
      if (channelId) this.videoForm.patchValue({ channelId: channelId });
    });
  }

  public setVideo(video: Video) {
    this.video = video;
    this.videoForm.patchValue({
      channelId: video.channelId,
      url: video.url,
      order: video.order
    });
  }

  public save() {
    this.video.channelId = this.videoForm.value["channelId"];
    this.video.url = this.videoForm.value["url"];
    this.video.description = this.videoForm.value["description"];
    this.video.order = this.videoForm.value["order"];

    this.videosService.getOEmbedVideo("youtube", this.video).subscribe(video =>
      this.videosService.addOrUpdateVideo(video).subscribe(
        result => this.router.navigate(["/videos/video/" + result])
        //errors =>  this.errors = errors
      )
    );
  }
}
