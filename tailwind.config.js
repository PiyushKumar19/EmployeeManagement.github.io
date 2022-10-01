/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./EmployeeManagement/**/*.cshtml",
    "./node_modules/flowbite/**/*.js"],
  theme: {
    extend: {},
  },
  plugins: [
    require('flowbite/plugin')
]

}
