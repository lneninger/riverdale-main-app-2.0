import { Component } from '@angular/core';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.scss']
})
export class TestimonialComponent {

    constructor() { }
    
    // Testimonial Carousel
    public testimonial = [{
      image: 'https://scienceoxford.com/wp-content/uploads/2018/03/avatar-male.jpg',
        name: 'anicia pardo',
        designation: 'Enterpreneur',
      description: 'HIPALANET helped me to tunning up my business process, bringing new ideas up which I ever thinked about, enhancing the quality of deliveries to my customer. The HIPALANET\'s team explained must of the development process envolved in my requirements which enhanced my expactations and my understanding of software solution integrations. I really appreciate the transformation the HIPALANET Solutions bringed to my company. ',
    }
      //, {
      //  image: 'assets/images/avtar/22.jpg',
      //  name: 'Adegoke Yusuff',
      //  designation: 'Content Writer',
      //  description: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.Contrary to popular belief, Lorem Ipsum is not simply random text.',
      //}, {
      //  image: 'assets/images/avtar/22.jpg',
      //  name: 'John Shipmen',
      //  designation: 'Lead Developer',
      //  description: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.Contrary to popular belief, Lorem Ipsum is not simply random text. ',
      //}
    ]

    // Testimonial Carousel Options
	public testimonialCarousel: any ={
	    loop:true,
        margin:5,
        nav:true,
        navClass:['owl-prev','owl-next'],
        navText:['<img src="assets/images/back.png">','<img src="assets/images/next.png">'],
        dots:false,
        responsive:{
            0:{
                items:1,
                dots:true,
                nav:false
            },
            600:{
                items:1,
                dots:true,
                nav:false
            },
            991:{
                items:1,
                margin:15,
            },
            1000:{
                items:1
            }
        }
	}

}
