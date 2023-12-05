using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Logging;
using UnityEditor;
using UnityEngine;
using EgoParadise.Utility.Extension;
using VContainer;
using VContainer.Unity;

namespace EgoParadise.EgoParadise.BlueTrail.Editor
{
    public static class VContainerContextMenuInjectAssigner
    {
        public static void UpdateVContainerInjectTargets(LifetimeScope scope)
        {
            var target = scope?.gameObject;
            if(scope == null || target == null)
            {
                Log.Warning($"The target {scope?.name} does not have a LifetimeScope component.");
                return;
            }
            Log.Info($"{nameof(VContainerContextMenuInjectAssigner)}: {scope.name} validate start.");

            var injectTargetsField = typeof(LifetimeScope).GetField("autoInjectGameObjects", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic);
            var objs = target.transform.GetComponentsInChildren<MonoBehaviour>()
                .Select(m => new {type = m.GetType(), instance = m,})
                .Where(m => m.type.FullName.StartsWith("UnityEngine.") == false)
                .ToArray();
            bool HasInjectAttribute(Type t)
            {
                return t.GetFields(BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Any(m => m.GetCustomAttributes<InjectAttribute>().Any()) ||
                    t.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Any(m => m.GetCustomAttributes<InjectAttribute>().Any())||
                    t.GetMethods(BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Any(m => m.GetCustomAttributes<InjectAttribute>().Any());
            }
            var injectableTypes = objs.Distinct(m => m.type)
                .Select(m => new {type = m.type, hasInject = HasInjectAttribute(m.type), })
                .Where(m => m.hasInject == true)
                .Select(m => m.type)
                .ToHashSet();
            var injectTargetObjs = new HashSet<GameObject>();
            foreach(var item in objs)
            {
                if(injectableTypes.Contains(item.type))
                {
                    injectTargetObjs.Add(item.instance.gameObject);
                }
            }
            injectTargetsField.SetValue(scope, injectTargetObjs.ToList());
            Log.Info($"{nameof(VContainerContextMenuInjectAssigner)}: {scope.name} validate succeed.");
        }
        [MenuItem("CONTEXT/LifetimeScope/UpdateVContainerInjectTargets")]
        public static void UpdateVContainerInjectTargets_LifetimeScope(MenuCommand command)
        {
            var target = command.context as LifetimeScope;
            UpdateVContainerInjectTargets(target);
        }
        [MenuItem("CONTEXT/GameObject/UpdateVContainerInjectTargets")]
        public static void UpdateVContainerInjectTargets_GameObject(MenuCommand command)
        {
            var target = command.context as GameObject;
            UpdateVContainerInjectTargets(target.GetComponent<LifetimeScope>());
        }
    }
}
