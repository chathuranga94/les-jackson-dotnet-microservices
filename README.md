DOCKER DESKTOP FOR MAC
VISUAL STUDIO FOR MAC OR VISUAL CODE

dotnet build
dotnet run

# Platform Service
docker build -t udarabibile/platformservice .
docker run -p 8080:80 -d udarabibile/platformservice
curl http://localhost:8080/api/platforms
docker push udarabibile/platformservice

kubectl version
kubectl apply -f platforms-depl.yaml
kubectl get deployments
kubectl get pods

kubectl delete deployment platforms-depl

# create node port for k8s
kubectl apply -f platforms-nodeport-service.yaml
kubectl get services
curl http://localhost:30977/api/platforms

kubectl delete deployment platforms-nodeport-service

# Command Service
dotnet new webapi -n CommandsService
dotnet add package Microsoft.EntityFrameworkCore.InMemory


PLATFORM SERVICE
curl http://localhost:5123/api/platforms
curl https://localhost:7205/api/platforms
curl -d '{"name":"Docker","publisher":"CloudNative","cost":"Free"}' -H 'Content-Type: application/json' -X POST https://localhost:7205/api/platforms


docker build -t udarabibile/commandservice .
docker run -p 8080:80 udarabibile/commandservice
docker push udarabibile/commandservice

# Restrt deployment after docker image changes
kubectl apply -f platforms-depl.yaml
kubectl rollout restart deployment platforms-depl
kubectl apply -f commands-depl.yaml

curl -d '{"name":"Docker","publisher":"CloudNative","cost":"Free"}' -H 'Content-Type: application/json' -X POST http://localhost:30977/api/platforms

# Install ingress-nginx in kubernetes
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.0/deploy/static/provider/cloud/deploy.yaml
kubectl get namespace
kubectl get pods --namespace=ingress-nginx
kubectl get services --namespace=ingress-nginx

# Update /etc/hosts file
127.0.0.1       acme.com
kubectl apply -f ingress-service.yaml
curl http://acme.com/api/platforms