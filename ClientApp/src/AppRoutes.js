import { Home } from './pages/Home'
import { DetailsPage } from './pages/DetailsPage/DetailsPage'
import { AddPage } from './pages/AddPage/AddPage'
import { AddMPage } from './pages/AddMPage/AddMPage'

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/details/:id',
    element: <DetailsPage />,
  },
  {
    path: '/add',
    element: <AddPage />,
  },
  {
    path: '/addM',
    element: <AddMPage />,
  },
]

export default AppRoutes
