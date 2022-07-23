<template>
<div class="box">
    <form @submit.prevent="registerUser">
      <h1 class="mb-8 text-3xl text-center">REGISTRO</h1>
      <input type="text" placeholder="Full Name" v-model="name" required />
      <input type="email" placeholder="Email" v-model="email" required />
      <input
        type="password"
        placeholder="Password"
        v-model="password"
        required
      />
      <button type="submit" class="registerbtn">Crear cuenta</button>
    </form>

    <div  style="margin-top: 10px">
      <a  style="text-decoration: none;" href="/login">Ya tienes cuenta, inicia sesión</a>
    </div>
    
  </div>
</template>

 <script>
export default {
  name: "RegisterView",
  data() {
    return {
      name: "", 
      email: "",
      password: "",
    };
  },
  methods: {
    async registerUser() {
      await fetch("https://localhost:44338/api/Users" , {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          name: this.name,
          email: this.email,
          password: this.password,
        }),
      })
        .then((response) => {
          if (response.status === 201) {
            this.$router.push("/login");
          } else {
            alert("Los datos son incorrectos o el correo ya esta registrado");
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
  
};
</script>

<style>
.box {
  width: 100%;
  max-width: 500px;
  border: 1px solid black;
    padding: 16px;
    border-radius:  10px;

}
* {box-sizing: border-box}

/* Add padding to containers */
.container {
  padding: 16px;
}

/* Full-width input fields */
input[type=text], input[type=password] , input[type=email] {
  width: 100%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

input[type=text]:focus, input[type=password]:focus, input[type=email]:focus {
  background-color: #ddd;
  outline: none;
}

/* Overwrite default styles of hr */
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

/* Set a style for the submit/register button */
.registerbtn {
  background-color: #28cf6d;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

.registerbtn:hover {
  opacity:1;
}

/* Add a blue text color to links */
a {
  color: rgb(104, 3, 12);
}

/* Set a grey background color and center the text of the "sign in" section */
.signin {
  background-color: #f1f1f1;
  text-align: center;
}
</style>