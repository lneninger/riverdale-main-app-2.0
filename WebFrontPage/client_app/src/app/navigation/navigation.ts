import { FuseNavigation } from '@fuse/types';

export const navigation: FuseNavigation[] = [
    {
        id: 'applications',
        title: 'Applications',
        translate: 'NAV.APPLICATIONS',
        type: 'group',
        icon: 'apps',
        children: [
            {
                id: 'dashboards',
                title: 'Dashboards',
                translate: 'NAV.DASHBOARDS',
                type: 'collapsable',
                icon: 'dashboard',
                children: [
                    {
                        id: 'analytics',
                        title: 'Analytics',
                        type: 'item',
                        url: '/apps/dashboards/analytics'
                    },
                    {
                        id: 'project',
                        title: 'Project',
                        type: 'item',
                        url: '/apps/dashboards/project'
                    }
                ]
            },

            {
                id: 'Recipes',
                title: 'Recipes',
                translate: 'NAV.RECIPIES',
                type: 'group',
                icon: 'apps',
                children: [

                ]
            },
            {
                id: '',
                title: 'Opportunities',
                translate: 'NAV.OPPORTUNITIES',
                type: 'item',
                icon: 'starts',
                url: '/apps/saleopportunities'
            },
            //{
            //    id: '',
            //    title: 'Recepies',
            //    translate: 'NAV.RECIPIES',
            //    type: 'item',
            //    icon: 'local_florist',
            //    url: '/apps/notification-groups'
            //},
            {
                id: '',
                title: 'Quotes',
                translate: 'NAV.QUOTES',
                type: 'item',
                icon: 'attach_money',
                url: '/apps/quotes'
            },
            //{
            //    id: '',
            //    title: 'Notification Groups',
            //    translate: 'NAV.CALENDAR',
            //    type: 'item',
            //    icon: 'today',
            //    url: '/apps/notification-groups'
            //},
            {
                id: 'masters',
                title: 'Masters',
                translate: 'NAV.MASTERS',
                type: 'group',
                icon: 'apps',
            },
            {
                id: 'customers',
                title: 'Customers',
                translate: 'NAV.CALENDAR',
                type: 'item',
                icon: 'person',
                url: '/apps/customers',
                permissions: ["Customer_*"],
            },
            {
                id: 'growers',
                title: 'Growers',
                translate: 'NAV.CALENDAR',
                type: 'item',
                icon: 'business',
                url: '/apps/growers',
                permissions: ["Grower_*"],
            },
            {
                id: 'product-colors',
                title: 'Product Colors',
                translate: 'NAV.COLORS',
                type: 'item',
                icon: 'color_lens',
                url: '/apps/product-colors',
                permissions: ["ProductColor_*"],
            },
            {
                id: 'products',
                title: 'Products',
                translate: 'NAV.PRODUCTS',
                type: 'item',
                icon: 'filter_vintage',
                url: '/apps/products',
                permissions: ["Product_*"],
            },
            {
                id: 'Settings',
                title: 'Settings',
                translate: 'NAV.SETTINGS',
                type: 'group',
                icon: 'gear',
                children: [

                ],
                permissions: ["Settings_*"],
            },
            {
                id: 'users',
                title: 'Users',
                translate: 'NAV.USERS',
                type: 'item',
                icon: 'person',
                url: '/apps/users',
                permissions: ["User_*"],
            },
            {
                id: 'roles',
                title: 'Roles',
                translate: 'NAV.ROLES',
                type: 'item',
                icon: 'lock',
                url: '/apps/roles',
                permissions: ["UserRole_*"],
            },
            {
                id: 'funza',
                title: 'Funza',
                translate: 'NAV.FUNZA',
                type: 'item',
                icon: 'business',
                url: '/apps/funza',
                permissions: ["Funza_*"],
            },
            //{
            //    id: 'calendar',
            //    title: 'Calendar',
            //    translate: 'NAV.CALENDAR',
            //    type: 'item',
            //    icon: 'today',
            //    url: '/apps/calendar'
            //},
            //{
            //    id: 'e-commerce',
            //    title: 'E-Commerce',
            //    translate: 'NAV.ECOMMERCE',
            //    type: 'collapsable',
            //    icon: 'chat_bubble',
            //    children: [
            //        {
            //            id: 'products',
            //            title: 'Products',
            //            type: 'item',
            //            url: '/apps/e-commerce/products',
            //            exactMatch: true
            //        },
            //        {
            //            id: 'productDetail',
            //            title: 'Product Detail',
            //            type: 'item',
            //            url: '/apps/e-commerce/products/1/printed-dress',
            //            exactMatch: true
            //        },
            //        {
            //            id: 'orders',
            //            title: 'Orders',
            //            type: 'item',
            //            url: '/apps/e-commerce/orders',
            //            exactMatch: true
            //        },
            //        {
            //            id: 'orderDetail',
            //            title: 'Order Detail',
            //            type: 'item',
            //            url: '/apps/e-commerce/orders/1',
            //            exactMatch: true
            //        }
            //    ]
            //},
            //{
            //    id: 'academy',
            //    title: 'Academy',
            //    translate: 'NAV.ACADEMY',
            //    type: 'item',
            //    icon: 'school',
            //    url: '/apps/academy'
            //},
            //{
            //    id: 'mail',
            //    title: 'Mail',
            //    translate: 'NAV.MAIL.TITLE',
            //    type: 'item',
            //    icon: 'email',
            //    url: '/apps/mail',
            //    badge: {
            //        title: '25',
            //        translate: 'NAV.MAIL.BADGE',
            //        bg: '#F44336',
            //        fg: '#FFFFFF'
            //    }
            //},
            //{
            //    id: 'mail-ngrx',
            //    title: 'Mail Ngrx',
            //    translate: 'NAV.MAIL_NGRX.TITLE',
            //    type: 'item',
            //    icon: 'email',
            //    url: '/apps/mail-ngrx',
            //    badge: {
            //        title: '13',
            //        translate: 'NAV.MAIL_NGRX.BADGE',
            //        bg: '#EC0C8E',
            //        fg: '#FFFFFF'
            //    }
            //},
            //{
            //    id: 'chat',
            //    title: 'Chat',
            //    translate: 'NAV.CHAT',
            //    type: 'item',
            //    icon: 'chat',
            //    url: '/apps/chat',
            //    badge: {
            //        title: '13',
            //        bg: '#09d261',
            //        fg: '#FFFFFF'
            //    }
            //},
            //{
            //    id: 'file-manager',
            //    title: 'File Manager',
            //    translate: 'NAV.FILE_MANAGER',
            //    type: 'item',
            //    icon: 'folder',
            //    url: '/apps/file-manager'
            //},
            //{
            //    id: 'contacts',
            //    title: 'Contacts',
            //    translate: 'NAV.CONTACTS',
            //    type: 'item',
            //    icon: 'account_box',
            //    url: '/apps/contacts'
            //},
            //{
            //    id: 'to-do',
            //    title: 'To-Do',
            //    translate: 'NAV.TODO',
            //    type: 'item',
            //    icon: 'check_box',
            //    url: '/apps/todo',
            //    badge: {
            //        title: '3',
            //        bg: '#FF6F00',
            //        fg: '#FFFFFF'
            //    }
            //},
            //{
            //    id: 'scrumboard',
            //    title: 'Scrumboard',
            //    translate: 'NAV.SCRUMBOARD',
            //    type: 'item',
            //    icon: 'assessment',
            //    url: '/apps/scrumboard'
            //}
        ]
    },
    
];
