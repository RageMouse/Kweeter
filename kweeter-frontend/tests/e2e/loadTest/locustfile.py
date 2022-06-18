from locust import HttpUser, task

class HelloWorldUser(HttpUser):
    @task
    def hello_world(self):
        self.client.get("/login")
        self.client.get("/about")
        self.client.get("/user")