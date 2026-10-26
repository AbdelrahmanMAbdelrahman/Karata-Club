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
import { BeltRankCreatePage } from './Features/BeltRank/Pages/BeltRank-create-page/BeltRank-create-page';
import { BeltRankListPage } from './Features/BeltRank/Pages/BeltRank-list-page/BeltRank-list-page';
import { BeltRankDetailPage } from './Features/BeltRank/Pages/BeltRank-detail-page/BeltRank-detail-page';
import { BeltRankPage } from './Features/BeltRank/Pages/BeltRank-page/BeltRank-page';
import { EnrollmentPage } from './Features/Enrollments/Pages/Enrollment-page/Enrollment-page';
import { EnrollmentListPage } from './Features/Enrollments/Pages/Enrollment-list-page/Enrollment-list-page';
import { EnrollmentCreatePage } from './Features/Enrollments/Pages/Enrollment-create-page/Enrollment-create-page';
import { EnrollmentDetailPage } from './Features/Enrollments/Pages/Enrollment-detail-page/Enrollment-detail-page';
import { BeltTestPage } from './Features/BeltTests/Pages/BeltTest-page/BeltTest-page';
import { BeltTestDetailPage } from './Features/BeltTests/Pages/BeltTest-detail-page/BeltTest-detail-page';
import { BeltTestCreatePage } from './Features/BeltTests/Pages/BeltTest-create-page/BeltTest-create-page';
import { SessionPage } from './Features/Sessions/Pages/Session-page/Session-page';
import { SessionCreatePage } from './Features/Sessions/Pages/Session-create-page/Session-create-page';
import { SessionDetailPage } from './Features/Sessions/Pages/session-detail-page/session-detail-page';
import { AttendenceListPage } from './Features/Attendence/Pages/attendence-list-page/attendence-list-page';
import { AttendencePage } from './Features/Attendence/Pages/attendence-page/attendence-page';

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
        {path:"BeltRankPage",component:BeltRankPage,
        children:[
            {path:"BeltRankCreatePage/:id",component:BeltRankCreatePage},
            {path:"BeltRankListPage",component:BeltRankListPage},
            {path:"BeltRankDetailPage/:id",component:BeltRankDetailPage},
        ]},
    {path:"SubscriptionPage",component:SubscriptionPage,
        children:[
            {path:"SubscriptionCreatePage/:id",component:SubscriptionCreatePage},
            {path:"SubscriptionListPage",component:SubscriptionListPage},
        ]},
    {path:"EnrollmentPage",component:EnrollmentPage,
        children:[
            {path:"EnrollmentCreatePage/:id",component:EnrollmentCreatePage},
            {path:"EnrollmentListPage",component:EnrollmentListPage},
            {path:"EnrollmentDetailPage/:id",component:EnrollmentDetailPage},
        ]},
    {path:"AttendencePage",component:AttendencePage,
        children:[
            {path:"AttendenceListPage/:id",component:AttendenceListPage},
        ]},
    {path:"SessionPage",component:SessionPage,
        children:[
            {path:"SessionCreatePage/:id",component:SessionCreatePage},
            {path:"SessionDetailPage/:id",component:SessionDetailPage},
        ]},
        {path:"BeltTestPage",component:BeltTestPage,
        children:[
            {path:"BeltTestCreatePage/:id",component:BeltTestCreatePage},
            {path:"BeltTestDetailPage/:id",component:BeltTestDetailPage},
        ]},
        ]
    }
];
