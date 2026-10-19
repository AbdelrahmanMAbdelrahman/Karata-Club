import { Routes } from '@angular/router';
import { HomePageComponent } from './Features/Global/Components/home-page-component/home-page-component';
import { InstructorPage } from './Features/Instructors/Pages/instructor-page/instructor-page';
import { InstructorCreatePage } from './Features/Instructors/Pages/instructor-create-page/instructor-create-page';
import { InstructorDetailPage } from './Features/Instructors/Pages/instructor-detail-page/instructor-detail-page';
import { InstructorListPage } from './Features/Instructors/Pages/instructor-list-page/instructor-list-page';
import { MemberPage } from './Features/Members/Pages/Member-page/Member-page';
import { MemberCreatePage } from './Features/Members/Pages/Member-create-page/Member-create-page';
import { MemberDetailPage } from './Features/Members/Pages/Member-detail-page/Member-detail-page';
import { MemberListPage } from './Features/Members/Pages/Member-list-page/Member-list-page';
import { SubscriptionListPage } from './Features/Subscriptions/Pages/Subscription-list-page/Subscription-list-page';
import { SubscriptionCreatePage } from './Features/Subscriptions/Pages/Subscription-create-page/Subscription-create-page';
import { SubscriptionPage } from './Features/Subscriptions/Pages/Subscription-page/Subscription-page';
import { CoursePage } from './Features/Courses/Pages/Course-page/Course-page';
import { CourseDetailPage } from './Features/Courses/Pages/Course-detail-page/Course-detail-page';
import { CourseListPage } from './Features/Courses/Pages/Course-list-page/Course-list-page';
import { CourseCreatePage } from './Features/Courses/Pages/Course-create-page/Course-create-page';

export const routes: Routes = [
    {path:"",component:HomePageComponent,
        children:[
    {path:"InstructorPage",component:InstructorPage,
        children:[
            {path:"InstructorCreatePage/:id",component:InstructorCreatePage},
            {path:"InstructorListPage",component:InstructorListPage},
            {path:"InstructorDetailPage/:id",component:InstructorDetailPage},
        ]},
    {path:"MemberPage",component:MemberPage,
        children:[
            {path:"MemberCreatePage/:id",component:MemberCreatePage},
            {path:"MemberListPage",component:MemberListPage},
            {path:"MemberDetailPage/:id",component:MemberDetailPage},
        ]},
    {path:"CoursePage",component:CoursePage,
        children:[
            {path:"CourseCreatePage/:id",component:CourseCreatePage},
            {path:"CourseListPage",component:CourseListPage},
            {path:"CourseDetailPage/:id",component:CourseDetailPage},
        ]},
    {path:"SubscriptionPage",component:SubscriptionPage,
        children:[
            {path:"SubscriptionCreatePage/:id",component:SubscriptionCreatePage},
            {path:"SubscriptionListPage",component:SubscriptionListPage},
        ]},

        ]
    }
];
