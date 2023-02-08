import { Home } from './pages/Home'
import { DetailsPage } from './pages/DetailsPage/DetailsPage'
import { AddPage } from './pages/AddPage/AddPage'

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
]

export default AppRoutes
